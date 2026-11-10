<Query Kind="Statements" />

int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

// a. Tổng số phần tử, số chẵn, số lẻ
mangSo.Count().Dump("a. Tổng số phần tử");
mangSo.Count(x => x % 2 == 0).Dump("a. Số phần tử chẵn");
mangSo.Count(x => x % 2 != 0).Dump("a. Số phần tử lẻ");

// b. Tổng, lớn nhất, nhỏ nhất
mangSo.Sum().Dump("b. Tổng các giá trị");
mangSo.Max().Dump("b. Giá trị lớn nhất");
mangSo.Min().Dump("b. Giá trị nhỏ nhất");

// c. Số giá trị khác nhau
mangSo.Distinct().Count().Dump("c. Số giá trị khác nhau");

// d. Nhóm theo số dư khi chia cho 5
var cauD = mangSo.GroupBy(x => x % 5)
                 .OrderBy(g => g.Key)
                 .Select(g => new { SoDu = g.Key, PhanTu = string.Join(", ", g) });
cauD.Dump("d. Phân nhóm theo số dư");