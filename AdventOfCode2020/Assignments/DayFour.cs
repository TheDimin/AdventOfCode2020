using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Assignments
{
    class DayFour : DayAssignment
    {
        class ID
        {
            public string BirthYear;
            public string IssueYear;
            public string EpirationYear;
            public string Height;
            public string HairColor;
            public string EyeColor;
            public string PassportID;
            public string CountryID;

            public override string ToString()
            {
                return $"byr:{BirthYear} iyr:{IssueYear} eyr:{EpirationYear} hgt:{Height} hcl:{HairColor} ecl:{EyeColor} pid:{PassportID} cid:{CountryID}";
            }

            public bool IsValid()
            {
                return (BirthYear != null && IssueYear != null && EpirationYear != null && Height != null &&
                        HairColor != null &&
                        EyeColor != null && PassportID != null);


            }
        }

        private ID[] ids;

        public override int Day { get; } = 4;
        public override void Init()
        {
            List<ID> allIds = new List<ID>();
            ID currenId = new ID();

            allIds.Add(currenId);
            foreach (var line in ReadLines())
            {
                if (line == "")
                {
                    currenId = new ID();
                    allIds.Add(currenId);
                    continue;
                }

                foreach (var inputField in line.Split(' '))
                {
                    var data = inputField.Split(':');

                    switch (data[0])
                    {
                        case "byr":
                            {

                                currenId.BirthYear = data[1];
                                break;
                            }
                        case "iyr":
                            {

                                currenId.IssueYear = data[1];
                                break;
                            }
                        case "eyr":
                            {

                                currenId.EpirationYear = data[1];
                                break;
                            }
                        case "hgt":
                            {

                                currenId.Height = data[1];
                                break;
                            }
                        case "hcl":
                            {

                                currenId.HairColor = data[1];
                                break;
                            }
                        case "ecl":
                            {

                                currenId.EyeColor = data[1];
                                break;
                            }
                        case "pid":
                            {

                                currenId.PassportID = data[1];
                                break;
                            }
                        case "cid":
                            {

                                currenId.CountryID = data[1];
                                break;
                            }
                    }
                }
            }

            ids = allIds.ToArray();
        }

        public override string A()
        {
            int validCounter = 0;
            foreach (var id in ids)
            {
                if (id.IsValid())
                {
                    validCounter++;
                }
            }

            return "Valid passports: " + validCounter;

        }

        public override string B()
        {
            int validCounter = 0;
            foreach (var id in ids)
            {
                if (id.IsValid())
                {

                    int bd = int.Parse(id.BirthYear);
                    if (bd < 1920 || bd > 2002)
                        continue;
                    int iyr = int.Parse(id.IssueYear);
                    if (iyr < 2010 || iyr > 2020)
                        continue;
                    int eyr = int.Parse(id.EpirationYear);
                    if (eyr < 2020 || eyr > 2030)
                        continue;

                    if (id.Height.Length == 4)
                    {
                        if (id.Height[2] != 'i' || id.Height[3] != 'n')
                            continue;
                        int height = int.Parse(id.Height.Substring(0, 2));
                        if (height < 59 || height > 76)
                            continue;
                    }
                    else if (id.Height.Length == 5)
                    {
                        if (id.Height[3] != 'c' || id.Height[4] != 'm')
                            continue;
                        int height = int.Parse(id.Height.Substring(0, 3));
                        if (height < 150 || height > 193)
                            continue;
                    }
                    else
                        continue;

                    if (id.HairColor[0] != '#' || id.HairColor.Length > 7)
                        continue;

                    Regex regex = new Regex("^[0-9a-f]{6}$");
                    if (!regex.IsMatch(id.HairColor.Substring(1, 6)))
                        continue;

                    List<string> eyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                    if (!eyeColors.Contains(id.EyeColor))
                        continue;

                    if (id.PassportID.Length != 9)
                        continue;

                    validCounter++;
                }
            }
            return ("Valid passports: " + validCounter);
        }
    }
}
