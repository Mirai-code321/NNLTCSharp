using Xunit;
using System.Collections.Generic;
using InHUFLIT;

namespace Bai1_InHUFLITTests
{
    public class TaoChuTests
    {
        [Fact]
        public void TaoChuF_H_Bang5()
        {
            var ketQua = Program.TaoChuF(5);
            var mongMuon = new List<string>
            {
                "* * * * *",
                "*        ",
                "* * * *  ",
                "*        ",
                "*        "
            };
            Assert.Equal(mongMuon, ketQua);
        }

        [Fact]
        public void TaoChuH_H_Bang5()
        {
            var ketQua = Program.TaoChuH(5);
            var mongMuon = new List<string>
            {
                "*       *",
                "*       *",
                "* * * * *",
                "*       *",
                "*       *"
            };
            Assert.Equal(mongMuon, ketQua);
        }

        [Fact]
        public void TaoChuL_H_Bang5()
        {
            var ketQua = Program.TaoChuL(5);
            var mongMuon = new List<string>
            {
                "*        ",
                "*        ",
                "*        ",
                "*        ",
                "* * * * *"
            };
            Assert.Equal(mongMuon, ketQua);
        }

        [Fact]
        public void TaoChuT_H_Bang5()
        {
            var ketQua = Program.TaoChuT(5);
            var mongMuon = new List<string>
            {
                "* * * * *",
                "    *    ",
                "    *    ",
                "    *    ",
                "    *    "
            };
            Assert.Equal(mongMuon, ketQua);
        }

        [Fact]
        public void TaoChuH_H_Bang3_KichThuocNho()
        {
            var ketQua = Program.TaoChuH(3);
            var mongMuon = new List<string>
            {
                "*   *",
                "* * *",
                "*   *"
            };
            Assert.Equal(mongMuon, ketQua);
        }
    }
}