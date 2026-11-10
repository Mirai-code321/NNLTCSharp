<Query Kind="Statements" />

string[] mangChuoi = { "đầu", "lòng", "hai", "à", "tố", "nga",
    "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

// a. Phần tử có 4 ký tự, sắp xếp tăng dần theo ký tự đầu
var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
cauA.Dump("Câu a");

// b. Dạng <chữ thường> - <CHỮ HOA>
var cauB = mangChuoi.Select(s => s.ToLower() + " - " + s.ToUpper());
cauB.Dump("Câu b");

// c. Phần tử chứa ký tự "u"
var cauC = mangChuoi.Where(s => s.Contains('u'));
cauC.Dump("Câu c");

// d. Các từ bắt đầu bằng chữ in hoa, nối lại thành một câu
var cauD = string.Join(" ", mangChuoi.Where(s => char.IsUpper(s[0])));
cauD.Dump("Câu d");