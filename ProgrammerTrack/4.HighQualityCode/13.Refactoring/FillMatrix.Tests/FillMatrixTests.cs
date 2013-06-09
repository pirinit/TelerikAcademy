using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FillMatrix.Tests
{
    [TestClass]
    public class FillMatrixTests
    {
        [TestMethod]
        public void Input5()
        {
            int n = 5;
            int[,] matrix = new int[n, n];
            DirectionHolder direction = new DirectionHolder();

            MatrixFiller.FillMatrixElements(matrix, direction);

            string actual = MatrixFiller.PrintMatrix(matrix, n * n);
            string expected = @"  1 13 14 15 16
 12  2 21 22 17
 11 23  3 20 18
 10 25 24  4 19
  9  8  7  6  5
";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input15()
        {
            int n = 15;
            int[,] matrix = new int[n, n];
            DirectionHolder direction = new DirectionHolder();

            MatrixFiller.FillMatrixElements(matrix, direction);

            string actual = MatrixFiller.PrintMatrix(matrix, n * n);
            string expected = @"   1  43  44  45  46  47  48  49  50  51  52  53  54  55  56
  42   2  81  82  83  84  85  86  87  88  89  90  91  92  57
  41 148   3  80 111 112 113 114 115 116 117 118 119  93  58
  40 149 201   4  79 110 132 133 134 135 136 137 120  94  59
  39 150 216 202   5  78 109 131 144 145 146 138 121  95  60
  38 151 215 217 203   6  77 108 130 143 147 139 122  96  61
  37 152 214 224 218 204   7  76 107 129 142 140 123  97  62
  36 153 213 223 225 219 205   8  75 106 128 141 124  98  63
  35 154 212 222 220 206 164 165   9  74 105 127 125  99  64
  34 155 211 221 207 163 184 185 166  10  73 104 126 100  65
  33 156 210 208 162 183 196 197 186 167  11  72 103 101  66
  32 157 209 161 182 195 200 199 198 187 168  12  71 102  67
  31 158 160 181 194 193 192 191 190 189 188 169  13  70  68
  30 159 180 179 178 177 176 175 174 173 172 171 170  14  69
  29  28  27  26  25  24  23  22  21  20  19  18  17  16  15
";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input24()
        {
            int n = 24;
            int[,] matrix = new int[n, n];
            DirectionHolder direction = new DirectionHolder();

            MatrixFiller.FillMatrixElements(matrix, direction);

            string actual = MatrixFiller.PrintMatrix(matrix, n * n);
            string expected = @"   1  70  71  72  73  74  75  76  77  78  79  80  81  82  83  84  85  86  87  88  89  90  91  92
  69   2 135 136 137 138 139 140 141 142 143 144 145 146 147 148 149 150 151 152 153 154 155  93
  68 346   3 134 192 193 194 195 196 197 198 199 200 201 202 203 204 205 206 207 208 209 156  94
  67 347 487   4 133 191 240 241 242 243 244 245 246 247 248 249 250 251 252 253 254 210 157  95
  66 348 520 488   5 132 190 239 279 280 281 282 283 284 285 286 287 288 289 290 255 211 158  96
  65 349 519 521 489   6 131 189 238 278 309 310 311 312 313 314 315 316 317 291 256 212 159  97
  64 350 518 546 522 490   7 130 188 237 277 308 330 331 332 333 334 335 318 292 257 213 160  98
  63 351 517 545 547 523 491   8 129 187 236 276 307 329 342 343 344 336 319 293 258 214 161  99
  62 352 516 544 564 548 524 492   9 128 186 235 275 306 328 341 345 337 320 294 259 215 162 100
  61 353 515 543 563 565 549 525 493  10 127 185 234 274 305 327 340 338 321 295 260 216 163 101
  60 354 514 542 562 574 566 550 526 494  11 126 184 233 273 304 326 339 322 296 261 217 164 102
  59 355 513 541 561 573 575 567 551 527 495  12 125 183 232 272 303 325 323 297 262 218 165 103
  58 356 512 540 560 572 576 568 552 528 496 376  13 124 182 231 271 302 324 298 263 219 166 104
  57 357 511 539 559 571 569 553 529 497 375 414 377  14 123 181 230 270 301 299 264 220 167 105
  56 358 510 538 558 570 554 530 498 374 413 444 415 378  15 122 180 229 269 300 265 221 168 106
  55 359 509 537 557 555 531 499 373 412 443 466 445 416 379  16 121 179 228 268 266 222 169 107
  54 360 508 536 556 532 500 372 411 442 465 480 467 446 417 380  17 120 178 227 267 223 170 108
  53 361 507 535 533 501 371 410 441 464 479 486 481 468 447 418 381  18 119 177 226 224 171 109
  52 362 506 534 502 370 409 440 463 478 485 484 483 482 469 448 419 382  19 118 176 225 172 110
  51 363 505 503 369 408 439 462 477 476 475 474 473 472 471 470 449 420 383  20 117 175 173 111
  50 364 504 368 407 438 461 460 459 458 457 456 455 454 453 452 451 450 421 384  21 116 174 112
  49 365 367 406 437 436 435 434 433 432 431 430 429 428 427 426 425 424 423 422 385  22 115 113
  48 366 405 404 403 402 401 400 399 398 397 396 395 394 393 392 391 390 389 388 387 386  23 114
  47  46  45  44  43  42  41  40  39  38  37  36  35  34  33  32  31  30  29  28  27  26  25  24
";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidInput()
        {
            string input = "5";
            string expected = @"Enter a positive number
";
            string actual = null;
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(input);
            
            try
            {
                Console.SetIn(sr);
                Console.SetOut(sw);
                MatrixFiller.ReadInput();

                actual = sw.ToString();
            }
            finally
            {
                sw.Dispose();
                sr.Dispose();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidInputNumberOutOfRange()
        {
            string input = "999\r\n5";
            string expected = "Enter a positive number\r\nYou haven't entered a correct positive" +
                " number.\nPlease enter number between 0 and 100.\r\n";
            string actual = null;
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(input);

            try
            {
                Console.SetIn(sr);
                Console.SetOut(sw);
                MatrixFiller.ReadInput();

                actual = sw.ToString();
            }
            finally
            {
                sw.Dispose();
                sr.Dispose();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidInputNaN()
        {
            string input = "99dsadasdasdsadsad9\r\n5";
            string expected = "Enter a positive number\r\nYou haven't entered a correct" +
                " number.\nPlease enter number between 0 and 100.\r\n";

            string actual = null;
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(input);

            try
            {
                Console.SetIn(sr);
                Console.SetOut(sw);
                MatrixFiller.ReadInput();

                actual = sw.ToString();
            }
            finally
            {
                sw.Dispose();
                sr.Dispose();
            }

            Assert.AreEqual(expected, actual);
        }
    }
}