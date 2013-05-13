function SetInitialPossition() {
    removedRocks = 0;
    turnNumber = 0;
    m[0] = new Array(39, 23, 45, 26, 35, 21, 19, 8, 24, 4, 36, 1, 25, 3, 29, 35, 41, 35, 24, 33, 26, 44, 50, 37, 22, 47, 41, 39, 12, 15, 14, 35, 6, 24, 47, 11, 3, 35, 5, 38, 32, 19, 22, 16, 39, 48, 45, 20, 5, 43);
    m[1] = new Array(23, 17, 1, 44, 30, 45, 24, 4, 38, 31, 46, 10, 40, 1, 46, 2, 7, 18, 33, 7, 30, 37, 1, 8, 23, 34, 48, 25, 3, 21, 34, 20, 42, 47, 35, 12, 44, 2, 38, 45, 31, 17, 7, 2, 24, 13, 26, 38, 2, 13);
    m[2] = new Array(38, 11, 16, 38, 15, 43, 23, 40, 11, 30, 36, 47, 26, 18, 44, 17, 34, 9, 6, 30, 38, 27, 13, 30, 50, 35, 11, 9, 10, 23, 10, 8, 47, 10, 27, 10, 21, 20, 21, 30, 48, 35, 2, 32, 48, 5, 48, 45, 33, 22);
    m[3] = new Array(19, 35, 8, 23, 40, 25, 35, 43, 39, 12, 32, 1, 7, 27, 2, 1, 17, 42, 34, 47, 14, 38, 26, 33, 4, 26, 32, 33, 46, 37, 16, 27, 39, 5, 25, 1, 39, 37, 36, 28, 33, 18, 17, 34, 45, 6, 47, 4, 31, 4);
    m[4] = new Array(49, 26, 5, 48, 32, 26, 20, 15, 44, 3, 48, 2, 47, 6, 13, 3, 2, 13, 31, 6, 49, 11, 37, 5, 8, 16, 20, 31, 27, 42, 7, 13, 28, 14, 1, 28, 19, 14, 17, 22, 42, 34, 31, 32, 22, 12, 22, 42, 5, 45);
    m[5] = new Array(42, 1, 49, 50, 15, 18, 43, 25, 10, 1, 34, 18, 17, 46, 35, 28, 50, 3, 24, 33, 15, 34, 7, 28, 7, 24, 37, 5, 49, 39, 23, 42, 1, 6, 14, 29, 49, 33, 36, 45, 5, 16, 38, 25, 18, 25, 37, 38, 34, 22);
    m[6] = new Array(40, 31, 13, 43, 37, 15, 38, 12, 20, 38, 5, 3, 45, 25, 5, 40, 21, 50, 1, 20, 39, 45, 49, 46, 33, 10, 32, 38, 21, 27, 50, 30, 8, 20, 49, 36, 12, 22, 16, 7, 50, 14, 43, 30, 43, 21, 47, 18, 35, 20);
    m[7] = new Array(43, 24, 49, 39, 20, 11, 28, 30, 32, 40, 35, 27, 46, 4, 46, 48, 20, 22, 14, 40, 49, 23, 32, 35, 3, 18, 12, 41, 32, 36, 5, 50, 6, 9, 32, 30, 26, 35, 42, 35, 18, 16, 38, 48, 26, 47, 23, 27, 46, 22);
    m[8] = new Array(33, 21, 20, 43, 4, 17, 8, 10, 19, 42, 8, 49, 22, 17, 5, 41, 39, 43, 39, 6, 8, 39, 15, 30, 48, 6, 27, 21, 40, 14, 37, 15, 23, 30, 14, 6, 29, 14, 18, 25, 24, 44, 10, 18, 16, 32, 22, 6, 34, 39);
    m[9] = new Array(4, 34, 28, 14, 31, 28, 24, 6, 11, 31, 39, 30, 28, 22, 34, 50, 8, 25, 28, 34, 11, 30, 21, 31, 35, 46, 5, 13, 33, 25, 6, 16, 6, 26, 34, 31, 45, 46, 49, 36, 33, 23, 3, 37, 36, 45, 16, 39, 17, 25);
    m[10] = new Array(48, 29, 1, 29, 24, 13, 47, 29, 36, 24, 11, 24, 36, 26, 24, 3, 38, 3, 5, 12, 26, 42, 1, 38, 27, 34, 46, 41, 30, 16, 30, 1, 9, 37, 5, 47, 10, 18, 17, 14, 13, 50, 17, 12, 21, 14, 1, 31, 13, 22);
    m[11] = new Array(37, 1, 42, 48, 30, 1, 39, 6, 8, 31, 8, 36, 18, 38, 19, 6, 29, 36, 6, 45, 13, 30, 29, 39, 10, 23, 35, 20, 17, 15, 50, 4, 38, 50, 6, 13, 39, 48, 29, 8, 6, 42, 32, 44, 24, 2, 8, 23, 46, 7);
    m[12] = new Array(19, 10, 7, 22, 4, 38, 7, 17, 20, 40, 43, 32, 5, 48, 32, 38, 15, 1, 17, 47, 9, 17, 5, 25, 37, 48, 29, 11, 18, 9, 43, 47, 20, 27, 43, 33, 3, 25, 32, 9, 19, 13, 10, 37, 35, 13, 37, 38, 7, 49);
    m[13] = new Array(49, 2, 6, 33, 35, 7, 10, 29, 7, 2, 31, 1, 28, 8, 28, 5, 45, 32, 49, 42, 15, 27, 8, 37, 12, 28, 11, 45, 16, 25, 31, 3, 36, 6, 49, 19, 22, 11, 49, 47, 16, 4, 26, 8, 38, 33, 29, 7, 9, 42);
    m[14] = new Array(7, 8, 16, 35, 22, 45, 19, 21, 8, 46, 16, 13, 32, 21, 29, 15, 23, 10, 33, 34, 33, 3, 26, 12, 2, 50, 45, 32, 38, 8, 33, 24, 45, 21, 27, 25, 4, 41, 1, 41, 44, 37, 9, 49, 10, 20, 48, 26, 8, 24);
    m[15] = new Array(6, 40, 23, 20, 45, 20, 22, 13, 15, 28, 5, 50, 47, 35, 44, 2, 33, 36, 30, 44, 43, 26, 21, 9, 14, 41, 1, 36, 13, 41, 25, 1, 39, 32, 49, 7, 30, 34, 20, 28, 37, 23, 37, 44, 40, 25, 5, 8, 37, 12);
    m[16] = new Array(46, 15, 31, 4, 14, 3, 12, 31, 29, 21, 28, 3, 38, 23, 26, 47, 46, 13, 4, 26, 6, 47, 25, 15, 16, 4, 35, 16, 24, 17, 46, 28, 26, 29, 37, 10, 20, 36, 18, 46, 49, 6, 49, 1, 35, 14, 18, 44, 29, 43);
    m[17] = new Array(5, 12, 7, 50, 40, 17, 38, 11, 18, 46, 8, 13, 25, 50, 27, 10, 36, 16, 28, 10, 45, 8, 30, 7, 41, 27, 15, 32, 19, 21, 48, 30, 39, 3, 24, 15, 22, 38, 21, 4, 8, 29, 50, 42, 44, 25, 1, 8, 25, 28);
    m[18] = new Array(2, 17, 19, 49, 47, 32, 50, 9, 14, 2, 6, 42, 48, 49, 28, 24, 22, 27, 13, 38, 49, 46, 24, 11, 37, 30, 16, 48, 3, 14, 25, 44, 46, 14, 20, 4, 27, 33, 22, 29, 7, 2, 44, 16, 32, 2, 14, 20, 3, 24);
    m[19] = new Array(45, 37, 29, 7, 43, 8, 13, 18, 2, 35, 11, 12, 39, 31, 48, 4, 3, 14, 5, 18, 1, 31, 17, 21, 39, 23, 18, 21, 49, 29, 2, 29, 50, 40, 31, 7, 15, 40, 12, 42, 10, 32, 38, 19, 46, 14, 18, 28, 50, 15);
    m[20] = new Array(35, 24, 15, 21, 9, 18, 20, 41, 42, 19, 24, 34, 32, 12, 49, 1, 42, 39, 14, 43, 27, 42, 49, 29, 2, 44, 10, 5, 3, 22, 29, 3, 14, 16, 17, 16, 37, 7, 22, 3, 22, 1, 41, 9, 5, 37, 34, 16, 13, 27);
    m[21] = new Array(39, 37, 8, 23, 33, 16, 42, 7, 25, 11, 37, 39, 48, 45, 31, 19, 47, 32, 35, 5, 33, 40, 21, 26, 1, 41, 25, 16, 11, 45, 42, 27, 33, 43, 45, 42, 7, 34, 1, 45, 50, 48, 43, 36, 12, 43, 14, 24, 19, 37);
    m[22] = new Array(34, 29, 22, 6, 45, 18, 2, 33, 32, 26, 18, 42, 15, 17, 45, 13, 16, 3, 37, 27, 41, 49, 34, 11, 34, 45, 48, 36, 15, 9, 27, 2, 48, 24, 12, 13, 5, 28, 48, 27, 40, 24, 3, 26, 28, 9, 34, 27, 42, 49);
    m[23] = new Array(28, 12, 37, 42, 47, 35, 45, 12, 22, 1, 21, 17, 19, 24, 49, 16, 44, 41, 5, 32, 9, 38, 5, 10, 38, 17, 47, 9, 34, 26, 12, 22, 45, 16, 31, 16, 7, 27, 19, 43, 6, 48, 7, 23, 6, 29, 28, 12, 15, 43);
    m[24] = new Array(22, 10, 41, 40, 8, 27, 4, 30, 39, 36, 28, 47, 39, 49, 23, 3, 43, 33, 1, 38, 14, 29, 14, 16, 33, 7, 4, 16, 11, 18, 32, 11, 19, 1, 35, 26, 41, 9, 39, 3, 48, 38, 33, 15, 9, 8, 50, 4, 36, 45);
    m[25] = new Array(12, 27, 30, 43, 46, 25, 8, 1, 24, 39, 19, 22, 5, 7, 36, 20, 48, 39, 28, 3, 25, 12, 35, 42, 32, 1, 25, 48, 46, 16, 8, 32, 38, 10, 40, 9, 39, 1, 34, 8, 16, 15, 30, 16, 29, 9, 24, 40, 11, 12);
    m[26] = new Array(26, 34, 20, 50, 42, 15, 1, 15, 25, 34, 3, 28, 23, 12, 40, 17, 47, 2, 31, 40, 50, 28, 19, 17, 47, 21, 37, 27, 4, 43, 1, 9, 36, 4, 33, 48, 18, 10, 43, 26, 9, 24, 26, 1, 6, 39, 42, 18, 26, 22);
    m[27] = new Array(9, 21, 13, 49, 16, 4, 22, 29, 12, 32, 33, 45, 42, 19, 30, 42, 50, 37, 10, 6, 32, 26, 2, 18, 12, 9, 29, 19, 1, 42, 31, 30, 50, 16, 42, 34, 33, 15, 7, 21, 47, 34, 13, 45, 19, 12, 47, 23, 39, 35);
    m[28] = new Array(12, 25, 4, 40, 38, 47, 48, 43, 46, 43, 10, 25, 20, 2, 3, 45, 27, 28, 46, 10, 36, 31, 39, 9, 48, 13, 8, 49, 12, 7, 30, 16, 30, 6, 18, 46, 26, 5, 38, 35, 22, 11, 29, 38, 10, 43, 17, 20, 46, 44);
    m[29] = new Array(26, 27, 45, 24, 46, 42, 25, 40, 49, 42, 34, 37, 31, 9, 40, 46, 36, 49, 1, 23, 9, 25, 14, 21, 10, 21, 39, 21, 15, 33, 34, 43, 11, 37, 41, 4, 12, 44, 50, 31, 48, 36, 30, 27, 43, 8, 2, 3, 48, 31);
    m[30] = new Array(19, 23, 35, 1, 14, 25, 15, 25, 4, 26, 17, 9, 42, 26, 44, 18, 37, 35, 42, 49, 17, 43, 11, 39, 34, 44, 18, 14, 38, 19, 18, 2, 16, 24, 38, 2, 41, 40, 38, 30, 26, 32, 27, 23, 20, 22, 36, 17, 14, 34);
    m[31] = new Array(16, 14, 39, 20, 3, 30, 25, 13, 30, 31, 47, 12, 16, 36, 9, 15, 44, 18, 38, 42, 28, 47, 13, 24, 35, 17, 39, 19, 13, 9, 1, 4, 3, 4, 13, 46, 21, 9, 28, 29, 11, 7, 33, 15, 16, 42, 15, 6, 28, 18);
    m[32] = new Array(29, 22, 7, 19, 17, 27, 47, 18, 14, 36, 44, 18, 23, 46, 11, 13, 33, 5, 2, 48, 47, 30, 15, 50, 37, 41, 31, 10, 20, 25, 24, 14, 35, 41, 23, 29, 48, 34, 38, 37, 50, 4, 45, 42, 35, 43, 35, 37, 4, 10);
    m[33] = new Array(11, 4, 31, 21, 50, 8, 7, 33, 27, 46, 37, 49, 40, 12, 30, 34, 32, 24, 33, 15, 49, 17, 49, 44, 36, 23, 15, 45, 6, 44, 7, 17, 16, 14, 10, 4, 21, 23, 21, 41, 2, 12, 41, 14, 6, 30, 6, 9, 3, 13);
    m[34] = new Array(21, 39, 11, 44, 40, 33, 28, 15, 35, 43, 38, 21, 3, 31, 32, 24, 49, 20, 30, 12, 1, 12, 25, 48, 6, 24, 36, 39, 30, 43, 9, 37, 4, 32, 36, 29, 6, 21, 22, 44, 9, 36, 49, 42, 39, 33, 24, 32, 36, 29);
    m[35] = new Array(41, 12, 9, 15, 14, 39, 16, 47, 39, 35, 43, 34, 2, 18, 21, 45, 4, 19, 29, 50, 8, 19, 43, 26, 34, 14, 35, 3, 16, 49, 12, 24, 8, 13, 20, 27, 14, 42, 32, 5, 26, 5, 25, 44, 15, 13, 19, 39, 20, 13);
    m[36] = new Array(4, 37, 21, 23, 20, 34, 39, 30, 25, 32, 45, 24, 36, 31, 11, 44, 6, 2, 18, 40, 27, 47, 45, 33, 15, 18, 32, 11, 21, 41, 17, 15, 46, 37, 9, 37, 38, 40, 1, 44, 12, 7, 24, 31, 32, 39, 14, 5, 19, 17);
    m[37] = new Array(21, 30, 36, 7, 42, 38, 9, 2, 28, 10, 35, 15, 31, 28, 50, 23, 24, 6, 16, 2, 25, 15, 40, 22, 3, 33, 30, 19, 7, 2, 23, 1, 44, 16, 1, 2, 45, 50, 32, 49, 43, 48, 3, 23, 9, 1, 4, 39, 41, 32);
    m[38] = new Array(14, 3, 16, 47, 16, 21, 17, 21, 36, 26, 23, 33, 22, 9, 13, 15, 37, 13, 50, 21, 29, 6, 34, 3, 32, 17, 13, 18, 13, 30, 41, 29, 26, 38, 20, 36, 48, 30, 35, 25, 15, 7, 27, 11, 27, 45, 11, 45, 14, 42);
    m[39] = new Array(40, 20, 3, 8, 19, 13, 15, 50, 9, 50, 9, 34, 46, 32, 5, 47, 21, 43, 30, 39, 13, 20, 37, 5, 42, 28, 27, 22, 40, 18, 7, 18, 39, 1, 9, 23, 31, 1, 24, 34, 1, 22, 35, 16, 32, 11, 45, 6, 31, 25);
    m[40] = new Array(18, 16, 26, 30, 21, 34, 48, 17, 42, 36, 43, 10, 41, 44, 41, 46, 9, 32, 46, 24, 41, 43, 7, 6, 13, 49, 2, 40, 10, 17, 33, 17, 10, 44, 39, 3, 13, 9, 31, 25, 14, 9, 38, 42, 41, 31, 42, 25, 37, 3);
    m[41] = new Array(14, 10, 7, 35, 26, 9, 21, 18, 23, 33, 9, 7, 26, 4, 27, 1, 48, 5, 39, 33, 50, 1, 22, 49, 27, 34, 19, 14, 22, 18, 11, 15, 24, 14, 20, 7, 4, 10, 14, 44, 43, 42, 9, 43, 16, 8, 34, 35, 16, 41);
    m[42] = new Array(34, 37, 4, 13, 39, 8, 9, 42, 41, 7, 46, 5, 22, 45, 33, 13, 34, 20, 48, 39, 42, 45, 40, 9, 43, 29, 33, 19, 1, 35, 49, 32, 35, 24, 28, 20, 11, 7, 18, 46, 1, 22, 4, 37, 46, 4, 21, 22, 25, 21);
    m[43] = new Array(1, 46, 43, 45, 46, 43, 15, 45, 21, 11, 25, 40, 41, 6, 8, 15, 21, 49, 17, 14, 2, 28, 2, 38, 20, 41, 4, 13, 39, 8, 12, 44, 30, 34, 4, 39, 40, 29, 36, 6, 16, 37, 8, 22, 12, 31, 48, 29, 32, 33);
    m[44] = new Array(23, 5, 12, 20, 24, 44, 42, 8, 26, 2, 11, 33, 32, 3, 14, 46, 12, 23, 5, 26, 32, 21, 32, 8, 37, 44, 31, 27, 40, 43, 25, 32, 6, 36, 7, 33, 11, 10, 48, 32, 4, 34, 45, 34, 5, 6, 9, 16, 20, 26);
    m[45] = new Array(24, 7, 2, 23, 5, 33, 50, 11, 32, 36, 10, 36, 2, 27, 17, 7, 14, 1, 13, 45, 28, 1, 18, 49, 13, 4, 37, 39, 23, 11, 20, 18, 2, 25, 5, 34, 28, 38, 1, 18, 25, 10, 33, 29, 39, 2, 20, 13, 29, 2);
    m[46] = new Array(35, 25, 42, 30, 47, 12, 38, 21, 17, 42, 35, 27, 22, 34, 23, 36, 23, 36, 41, 1, 25, 4, 22, 8, 50, 21, 10, 1, 5, 23, 47, 4, 49, 10, 37, 49, 31, 49, 50, 30, 2, 33, 25, 6, 8, 6, 30, 16, 47, 28);
    m[47] = new Array(44, 39, 2, 35, 1, 38, 9, 40, 13, 17, 12, 16, 38, 13, 31, 19, 35, 14, 50, 25, 5, 37, 41, 21, 49, 42, 30, 16, 1, 44, 42, 44, 5, 28, 29, 8, 3, 15, 9, 49, 40, 42, 36, 33, 19, 36, 46, 12, 26, 39);
    m[48] = new Array(22, 17, 22, 24, 7, 48, 31, 36, 9, 44, 39, 19, 26, 18, 11, 35, 23, 17, 20, 5, 1, 35, 13, 2, 8, 3, 14, 47, 18, 40, 12, 22, 25, 33, 4, 22, 10, 22, 29, 1, 41, 47, 4, 18, 8, 1, 25, 36, 28, 4);
    m[49] = new Array(23, 3, 13, 16, 37, 12, 6, 40, 29, 23, 13, 41, 5, 28, 48, 1, 40, 29, 7, 13, 45, 42, 4, 10, 39, 10, 34, 1, 2, 39, 11, 41, 36, 40, 20, 13, 46, 43, 16, 21, 44, 7, 38, 1, 43, 27, 20, 7, 11, 47);
    turns[0] = new Array(1, 5, 2);
    turns[1] = new Array(1, 16, 42);
    turns[2] = new Array(1, 18, 3);
    turns[3] = new Array(1, 18, 13);
    turns[4] = new Array(1, 27, 3);
    turns[5] = new Array(1, 46, 37);
    turns[6] = new Array(1, 47, 24);
    turns[7] = new Array(1, 19, 14);
    turns[8] = new Array(1, 3, 46);
    turns[9] = new Array(1, 23, 26);
    turns[10] = new Array(1, 26, 16);
    turns[11] = new Array(1, 28, 5);
    turns[12] = new Array(1, 32, 20);
    turns[13] = new Array(1, 16, 16);
    turns[14] = new Array(1, 40, 15);
    turns[15] = new Array(1, 6, 12);
    turns[16] = new Array(1, 9, 36);
    turns[17] = new Array(1, 28, 15);
    turns[18] = new Array(1, 43, 3);
    turns[19] = new Array(1, 36, 15);
    turns[20] = new Array(1, 15, 20);
    turns[21] = new Array(1, 24, 16);
    turns[22] = new Array(1, 34, 29);
    turns[23] = new Array(1, 41, 40);
    turns[24] = new Array(1, 43, 5);
    turns[25] = new Array(1, 27, 29);
    turns[26] = new Array(1, 29, 9);
    turns[27] = new Array(1, 31, 45);
    turns[28] = new Array(1, 40, 43);
    turns[29] = new Array(1, 20, 7);
    turns[30] = new Array(1, 42, 8);
    turns[31] = new Array(1, 24, 3);
    turns[32] = new Array(1, 30, 37);
    turns[33] = new Array(1, 43, 11);
    turns[34] = new Array(1, 47, 40);
    turns[35] = new Array(1, 43, 28);
    turns[36] = new Array(1, 43, 35);
    turns[37] = new Array(1, 49, 29);
    turns[38] = new Array(1, 10, 23);
    turns[39] = new Array(1, 5, 46);
    turns[40] = new Array(1, 12, 46);
    turns[41] = new Array(1, 32, 39);
    turns[42] = new Array(1, 33, 10);
    turns[43] = new Array(1, 36, 35);
    turns[44] = new Array(1, 3, 38);
    turns[45] = new Array(1, 9, 44);
    turns[46] = new Array(1, 29, 16);
    turns[47] = new Array(1, 33, 24);
    turns[48] = new Array(1, 35, 26);
    turns[49] = new Array(1, 1, 25);
}
