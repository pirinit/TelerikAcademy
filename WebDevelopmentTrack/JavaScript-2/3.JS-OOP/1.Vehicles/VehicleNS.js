;var vehicleNS = (function () {
    Function.prototype.inherit = function(parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    }
    //enums
    var spinDirection = Object.freeze({
        clockwise: 0,
        counterClockwise: 1
    });

    var driveMode = Object.freeze({
        land: 0,
        water: 1
    });

    //vehicles
    function Vehicle(speed, propulsionUnitsArr) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnitsArr;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0, length = this.propulsionUnits.length; i < length; i++) {
            this.speed += this.propulsionUnits[i].getPropulsion();
        }
    }

    // the constructor of LandVehicle takes only speed and wheelRadius,
    // because i want to be shure that the land vehicle has exactly 4 wheels
    function LandVehicle(speed, wheelsRadius) {
        var args = [];
        args.push(speed);
        var wheels = [];
        for (var i = 0; i < 4; i++) {
            wheels.push(new Wheel(wheelsRadius));
        }
        args.push(wheels);
        Vehicle.apply(this, args);
    }
    LandVehicle.inherit(Vehicle);

    // the AirVehicle has only one nozzle by design
    function AirVehicle(speed, nozzle) {
        var args = [];
        args.push(speed);
        args.push([nozzle]);
        Vehicle.apply(this, args);
    }
    AirVehicle.inherit(Vehicle);
    AirVehicle.prototype.switchAfterburner = function () {
        this.propulsionUnits[0].isAfterBurnerOn = !this.propulsionUnits[0].isAfterBurnerOn;
    }

    function WaterVehicle(speed, propelersCount, finCount, spinDirect) {
        var args = [];
        args.push(speed);
        var propelers = [];
        for (var i = 0; i < propelersCount; i++) {
            propelers.push(new Propeller(finCount, spinDirect));
        }
        args.push(propelers);
        Vehicle.apply(this, args);
    }
    WaterVehicle.inherit(Vehicle);
    WaterVehicle.prototype.setSpinDirection = function(spinDirect) {
        for (var i = 0, length = this.propulsionUnits.length; i < length; i++) {
            this.propulsionUnits[i].spinDirection = spinDirect;
        }
    }

    function AmphibiousVehicle(speed, propeller, wheelsArr, driveMod) {
        var args = [];
        args.push(speed);
        wheelsArr.push(propeller);
        args.push(wheelsArr);
        Vehicle.apply(this, args);
        this.driveMode = driveMod;
    }
    AmphibiousVehicle.inherit(Vehicle);
    // the vehicle stops when switching driveModes
    AmphibiousVehicle.prototype.setDriveMode = function (driveMod) {
        this.driveMode = driveMod;
        this.speed = 0;
    }
    AmphibiousVehicle.prototype.accelerate = function () {
        for (var i = 0, length = this.propulsionUnits.length; i < length; i++) {
            if (this.driveMode === driveMode.water && this.propulsionUnits[i] instanceof Propeller) {
                this.speed += this.propulsionUnits[i].getPropulsion();
            }
            else if (this.driveMode === driveMode.land && this.propulsionUnits[i] instanceof Wheel) {
                this.speed += this.propulsionUnits[i].getPropulsion();
            }
        }
    }

    //propulsion units
    function PropulsionUnit() {
    }

    function Wheel(radius) {
        this.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);
    Wheel.prototype.getPropulsion = function () {
        return 2 * Math.PI * this.radius;
    }

    function Nozzle(power, isAfterBurnerOn) {
        this.power = power;
        this.isAfterBurnerOn = isAfterBurnerOn;
    }

    Nozzle.inherit(PropulsionUnit);
    Nozzle.prototype.getPropulsion = function () {
        var propulsion = this.power;
        if (this.isAfterBurnerOn) {
            propulsion *= 2;
        }

        return propulsion;
    }

    function Propeller(finCount, spinDirect) {
        this.finCount = finCount;
        this.spinDirection = spinDirect;
    }
    Propeller.inherit(PropulsionUnit);
    Propeller.prototype.getPropulsion = function () {
        var propulsion = this.finCount;
        if (this.spinDirection === spinDirection.counterClockwise) {
            propulsion *= -1;
        }

        return propulsion;
    }

    return {
        spinDirection: spinDirection,
        Wheel: Wheel,
        Nozzle: Nozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    }
}) ();