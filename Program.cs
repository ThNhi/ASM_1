using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASM_1
{
    public class SinhVien
    {
        public string maSV { get; set; }

        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }

        public SinhVien()
        {

        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh,
            string diaChi, string dienThoai)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }

        public string seeInfor => $"Ma SV: {maSV}, Ho ten: {hoTen}, Ngay sinh: {ngaySinh.ToString("MM/dd/yyyy")}, Dia chi: {diaChi}, Dien thoai: {dienThoai}";
    }

    public class studentManagement
    {
        public ArrayList listSV = new ArrayList(50);

        public SinhVien Find(string maSV)
        {
            foreach (SinhVien sv in listSV)
            {
                if (sv.maSV.Equals(maSV))
                {
                    return sv;
                }
            }
            return null;
        }

        public void PrintAll()
        {
            foreach (SinhVien sv in listSV)
            {
                Console.WriteLine(sv.seeInfor);
            }
        }

        public void updateSV(SinhVien sinhVien)
        {
            int i = 0;
            foreach (SinhVien sv in listSV)
            {
                if (sv.maSV.Equals(sinhVien.maSV))
                {
                    listSV[i] = sinhVien;
                    return;
                }
                i++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ASM_1";

            studentManagement sm = new studentManagement();


            sm.listSV.Add(new SinhVien("123", "Phong Thanh Nhi", DateTime.Parse("02/12/2000"), "hcm", "0601386565"));
            sm.listSV.Add(new SinhVien("456", "Nguyen Thi Hoa", DateTime.Parse("05/15/2000"), "hcm", "0937536948"));
            sm.listSV.Add(new SinhVien("789", "Tran Trung Nhat", DateTime.Parse("10/10/2000"), "hai phong", "0334455996"));
            sm.listSV.Add(new SinhVien("321", "Tran Trui", DateTime.Parse("12/12/2000"), "bien hoa", "0766745678"));

            string choice;

            do
            {
                Console.WriteLine("1. List all");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Find");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Exit");

                Boolean checkChoice;

                do
                {
                    Console.Write("Choose 1 number to continue : ");
                    choice = Console.ReadLine();
                    checkChoice = Regex.Match(choice, @"^[1-5]{1}$").Success;
                    if (choice.Equals("5"))
                    {
                        Environment.Exit(0);
                    }
                    if (checkChoice == false)
                    {
                        Console.WriteLine("Must be number (1->5)!!!Try again.");
                        checkChoice = false;
                    }
                } while (checkChoice == false);

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("----List of SinhVien----");
                        sm.PrintAll();
                        break;
                    ////////////////////////////////////////////////////////////
                    case "2":
                        Console.WriteLine("----Add----");

                        Boolean checkMaSV;
                        string maSV;
                        do
                        {
                            Console.Write("Input maSV: ");
                            maSV = Console.ReadLine();
                            if (sm.Find(maSV) == null)
                            {

                                checkMaSV = Regex.Match(maSV, @"^[0-9]{3}$").Success;

                                if (checkMaSV == false)
                                {
                                    Console.WriteLine("maSV must have 3-digit!!! Try again.");
                                }
                            }
                            else
                            {
                                checkMaSV = false;
                                Console.WriteLine("maSV already exist!!! Try again.");
                            }
                        } while (checkMaSV == false);

                        Boolean checkHoTen;
                        string hoTen;
                        do
                        {
                            Console.Write("Input hoTen: ");
                            hoTen = Console.ReadLine();
                            checkHoTen = Regex.Match(hoTen, @"^([a-zA-Z ]{1,50}[^(\s)])$").Success;
                            if (checkHoTen == false)
                            {
                                Console.WriteLine("Invalid input!!! Try again.");
                            }
                        } while (checkHoTen == false);

                        DateTime ngaySinh;
                        Boolean checkNgaySinh;
                        do
                        {
                            ngaySinh = new DateTime();
                            try
                            {
                                checkNgaySinh = true;
                                Console.Write("Input ngaySinh: ");
                                ngaySinh = DateTime.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                checkNgaySinh = false;
                                Console.WriteLine("Invalid input => MM/dd/yyyy!!! Try again.");
                            }
                        } while (checkNgaySinh == false);

                        Boolean checkDiachi;
                        string diaChi;
                        do
                        {
                            Console.Write("Input diaChi: ");
                            diaChi = Console.ReadLine();
                            checkDiachi = Regex.Match(diaChi, @"^([a-zA-Z0-9 ]{1,50}[^(\s)])$").Success;
                            if (checkDiachi == false)
                            {
                                Console.WriteLine("Invalid input!!! Try again.");
                            }
                        } while (checkDiachi == false);


                        Boolean checkSDT;
                        string dienThoai;
                        do
                        {
                            Console.Write("Input SDT: ");
                            dienThoai = Console.ReadLine();
                            checkSDT = Regex.Match(dienThoai, @"^([0-9]{10,12})$").Success;

                            if (checkSDT == false)
                            {
                                Console.WriteLine("Must have 10-12 digits!!! Try again.");
                            }
                        } while (checkSDT == false);

                        SinhVien sv = new SinhVien(maSV, hoTen, ngaySinh, diaChi, dienThoai);
                        sm.listSV.Add(sv);
                        break;


                    ////////////////////////////////////////////////////////////    
                    case "3":
                        Console.WriteLine("----Find----");
                        Console.Write("Input maSV: ");
                        maSV = Console.ReadLine();

                        if (sm.Find(maSV) == null)
                        {
                            Console.WriteLine("Not found!");
                        }
                        else
                        {
                            Console.WriteLine(sm.Find(maSV).seeInfor);
                        }
                        break;

                    ////////////////////////////////////////////////////////////
                    case "4":
                        Console.WriteLine("----Update----");
                        Console.Write("Input maSV: ");
                        maSV = Console.ReadLine();

                        if (sm.Find(maSV) != null)
                        {
                            do
                            {
                                Console.Write("Input hoTen: ");
                                hoTen = Console.ReadLine();
                                checkHoTen = Regex.Match(hoTen, @"^([a-zA-Z ]{1,50}[^(\s)])$").Success;
                                if (checkHoTen == false)
                                {
                                    Console.WriteLine("Invalid input!!! Try again.");
                                }
                            } while (checkHoTen == false);

                            do
                            {
                                ngaySinh = new DateTime();
                                try
                                {
                                    checkNgaySinh = true;
                                    Console.Write("Input ngaySinh: ");
                                    ngaySinh = DateTime.Parse(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    checkNgaySinh = false;
                                    Console.WriteLine("Invalid input => MM/dd/yyyy!!! Try again.");
                                }
                            } while (checkNgaySinh == false);

                            do
                            {
                                Console.Write("Input diaChi: ");
                                diaChi = Console.ReadLine();
                                checkDiachi = Regex.Match(diaChi, @"^([a-zA-Z0-9 ]{1,50}[^(\s)])$").Success;
                                if (checkDiachi == false)
                                {
                                    Console.WriteLine("Invalid input!!! Try again.");
                                }
                            } while (checkDiachi == false);

                            do
                            {
                                Console.Write("Input SDT: ");
                                dienThoai = Console.ReadLine();
                                checkSDT = Regex.Match(dienThoai, @"^([0-9]{10,12})$").Success;

                                if (checkSDT == false)
                                {
                                    Console.WriteLine("Must have 10 - 12 digits!!! Try again.");
                                }
                            } while (checkSDT == false);

                            sv = new SinhVien(maSV, hoTen, ngaySinh, diaChi, dienThoai);

                            sm.updateSV(sv);

                            Console.WriteLine("Success!!!");
                        }
                        else
                        {
                            Console.WriteLine("Not found!!!");
                        }
                        break;
                }
            } while (choice.Equals("1") || choice.Equals("2") || choice.Equals("3") || choice.Equals("4"));

        }
    }
}
