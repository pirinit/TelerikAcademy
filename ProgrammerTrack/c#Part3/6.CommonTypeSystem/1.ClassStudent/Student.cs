using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ClassStudent
{
    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string midleName;
        private string lastName;
        private string ssn;
        private string mobilePhone;
        private string email;
        private byte? course;
        private Specialties specialty;
        private Universities university;
        private Faculties faculty;

        public Faculties Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public Universities University
        {
            get { return university; }
            set { university = value; }
        }

        public Specialties Specialty
        {
            get { return specialty; }
            set { this.specialty = value; }
        }

        public byte? Course
        {
            get { return course; }
            set { this.course = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { this.mobilePhone = value; }
        }

        public string Ssn
        {
            get { return ssn; }
            private set { this.ssn = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { this.lastName = value; }
        }

        public string MiddleName
        {
            get { return midleName; }
            private set { this.midleName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set { this.firstName = value; }
        }

        public Student(string firstName, string middleName, string lastName, string ssn, string mobilePhone = null,
            string email = null, byte? course = null, Specialties specialty = Specialties.Undefined,
            Universities university = Universities.Undefined, Faculties faculty = Faculties.Undefined)
        {
            this.firstName = firstName;
            this.midleName = middleName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.mobilePhone = mobilePhone;
            this.email = email;
            this.course = course;
            this.specialty = specialty;
            this.university = university;
            this.faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            Student other = obj as Student;
            if(other == null)
            {
                return false;
            }
            if(!Object.Equals(this.ssn, other.ssn)
                || !Object.Equals(this.firstName, other.firstName)
                || !Object.Equals(this.midleName, other.midleName)
                || !Object.Equals(this.lastName, other.lastName))
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Student first, Student second)
        {
            return Object.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Object.Equals(first, second);
        }

        public override int GetHashCode()
        {
            //using only mandatory and not mutable fields to calculate hash code
            //so the hash code of the current student will ALWAYS be the same
            int hash = this.FirstName.GetHashCode()
                ^ this.midleName.GetHashCode()
                ^ this.lastName.GetHashCode()
                ^ this.ssn.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            string text = string.Format("Student: {0} {1} {2}\nStudies: {3}, {4}, {5}.",
                this.firstName ?? "<no name>", this.midleName ?? "<no name>", this.lastName ?? "<no name>",
                this.specialty, this.faculty, this.university);
            return text;
        }

        public Student Clone()
        {
            string firstName = this.firstName != null ? string.Copy(this.firstName) : null;
            string midleName = this.midleName != null ? string.Copy(this.midleName) : null;
            string lastName = this.lastName != null ? string.Copy(this.lastName) : null;
            string ssn = this.ssn != null ? string.Copy(this.ssn) : null;

            Student clone = new Student(firstName, midleName, lastName, ssn);
            clone.mobilePhone = this.mobilePhone != null ? string.Copy(this.mobilePhone) : null;
            clone.email = this.email != null ? string.Copy(this.email) : null;
            clone.course = this.course;
            clone.specialty = this.specialty;
            clone.university = this.university;
            clone.faculty = this.faculty;
            return clone;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student other)
        {
            if (this.firstName != other.firstName)
            {
                return this.firstName.CompareTo(other.firstName);
            }
            if (this.midleName != other.midleName)
            {
                return this.midleName.CompareTo(other.midleName);
            }
            if (this.lastName != other.lastName)
            {
                return this.lastName.CompareTo(other.lastName);
            }

            if (this.ssn != other.ssn)
            {
                return this.ssn.CompareTo(other.ssn);
            }
            return 0;
        }
    }
}
