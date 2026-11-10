<Query Kind="Statements" />

int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

// a. Chia hết cho cả 4 và 3 (tức là chia hết cho 12)
var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
cauA.Dump("Câu a");

// b. Nhỏ hơn hoặc bằng 3
var cauB = mangSo.Where(x => x <= 3);
cauB.Dump("Câu b");

// c. Số chẵn chia đôi, số lẻ giữ nguyên
var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
cauC.Dump("Câu c");