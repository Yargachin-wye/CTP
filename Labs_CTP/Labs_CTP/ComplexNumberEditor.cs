using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public enum PartToEdit
    {
        Real, Imag
    };
    public enum NumberPartToEdit
    {
        Left, Right
    };

    public class ComplexNumberEditor
    {
        string pNum;
        PartToEdit mode;
        NumberPartToEdit numberMode;
        string zero = "0,+i*0,";
        string separatorParts = "i*";
        string separatorNumber = ",";

        public ComplexNumberEditor()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
        }

        public bool IsZero()
        {
            string tmp = pNum;
            if (tmp[0] == '-')
                tmp = tmp.Substring(1);
            tmp = tmp.Replace('-', '+');
            if (tmp == zero)
                return true;
            else
                return false;
        }

        public string ToggleMinus()
        {
            if (mode == PartToEdit.Real)
            {
                if (pNum[0] == '-')
                    pNum = pNum.Substring(1);
                else
                    pNum = '-' + pNum;
            }
            else
            {
                pNum = pNum.Substring(0, pNum.IndexOf(separatorParts)) + "-" +
                       pNum.Substring(pNum.IndexOf(separatorParts));
            }
            return pNum;
        }

        public PartToEdit ToggleMode()
        {
            if (mode == PartToEdit.Real)
                mode = PartToEdit.Imag;
            else
                mode = PartToEdit.Real;
            return mode;
        }

        public NumberPartToEdit ToggleNumberMode()
        {
            if (numberMode == NumberPartToEdit.Left)
                numberMode = NumberPartToEdit.Right;
            else
                numberMode = NumberPartToEdit.Left;
            return numberMode;
        }

        public string AddNumber(int a)
        {
            if (a < 0 || a > 9)
                return pNum;
            int ind = pNum.IndexOf(separatorParts);
            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        pNum = a + pNum.Substring(1);
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        pNum = '-' + a + pNum.Substring(2);
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        pNum = pNum.Insert(frstNumbSep, a.ToString());
                    }
                }
                else
                    pNum.Insert(ind - 1, a.ToString());
            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 2;
                    if (pNum[ind] == '0')
                        pNum = pNum.Substring(0, ind - 1) + a + pNum.Substring(ind + 1);
                    else
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        pNum.Insert(lastNumbSep, a.ToString());
                    }
                }
                else
                    pNum += '0' + a;
            }
            return pNum;
        }

        public string AddZero()
        {
            return AddNumber(0);
        }

        public string DelNumber()
        {
            int ind = pNum.IndexOf(separatorParts);
            if (mode == PartToEdit.Real)
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    if (pNum[0] == '0')
                        return pNum;
                    else if (pNum[0] == '-' && pNum[1] == '0')
                        return pNum;
                    else
                    {
                        int frstNumbSep = pNum.IndexOf(separatorNumber);
                        pNum = pNum.Remove(frstNumbSep - 1, 1);
                        if (pNum[0] == ',')
                            pNum = '0' + pNum;
                    }
                }
                else
                {
                    int r = 0;
                    if (!int.TryParse(pNum[ind - 2].ToString(), out r))
                        return pNum;
                    pNum = pNum.Remove(ind - 2, 1);
                }
            }
            else
            {
                if (numberMode == NumberPartToEdit.Left)
                {
                    ind += 2;
                    if (pNum[ind] == '0')
                        return "0";
                    else
                    {
                        int lastNumbSep = pNum.LastIndexOf(',');
                        if (pNum[lastNumbSep - 2] == '*')
                            pNum = pNum.Substring(0, lastNumbSep - 1) + '0' + pNum.Substring(lastNumbSep);
                        else
                            pNum.Remove(lastNumbSep - 1, 1);
                    }
                }
                else
                {
                    if (pNum[pNum.Length - 1] == ',')
                        return pNum;
                    else
                        pNum.Remove(pNum.Length - 1);
                }
            }
            return pNum;
        }

        public string Clear()
        {
            pNum = zero;
            mode = PartToEdit.Real;
            numberMode = NumberPartToEdit.Left;
            return pNum;
        }

        public string Edit(int command)
        {
            switch (command)
            {
                case 0:
                    ToggleMinus();
                    break;
                case 1:
                    {
                        Console.Write("Enter number to add: ");
                        int num;
                        num = Console.Read();
                        AddNumber(num);
                        break;
                    }
                case 2:
                    AddZero();
                    break;
                case 3:
                    DelNumber();
                    break;
                case 4:
                    Clear();
                    break;
                case 5:
                    {
                        Console.WriteLine("Enter string to write: ");
                        string inp;
                        inp = Console.ReadLine();
                        WriteNumber(inp);
                        break;
                    }
                default:
                    break;
            }
            return pNum;
        }

        public string WriteNumber(string otherNumber)
        {
            pNum = otherNumber;
            return pNum;
        }

        public string ReadNumber()
        {
            return pNum;
        }
    }
}
