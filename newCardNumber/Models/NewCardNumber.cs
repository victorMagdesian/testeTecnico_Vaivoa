using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NewCardNumber.Models
{

    public class NewCardNumberClass
    {

        static string MastercardPrefix = "51";
        static string VisaPrefix = "4";

        public string CreateCardNumber(string brand)
        {
            switch (brand)
            {
                case "v":
                    string CardNum = VisaPrefix;
                    long n = 0;
                    long LongAux = 0;
                    long LongAux2 = 0;
                    long x = 100000000000000;
                    long sum = 0;
                    Random random = new Random();


                    CardNum += random.Next(100000000, 999999999);
                    CardNum += random.Next(10000, 99999);

                    LongAux = Convert.ToInt64(CardNum);

                    LongAux2 = LongAux;

                    for (int i = 0; i < CardNum.Length; i++)
                    {
                        n = LongAux2 / x;
                        switch (i)
                        {
                            case 0:
                            case 2:
                            case 4:
                            case 6:
                            case 8:
                            case 10:
                            case 12:
                            case 14:
                                if (n < 5) { sum += n * 2; } else { n = n * 2; sum += ((n / 10) + (n % 10)); }
                                break;

                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 9:
                            case 11:
                            case 13:
                                sum += n;
                                break;
                        }
                        LongAux2 = LongAux2 % x;
                        x = x / 10;
                    }
                    sum = ((sum / 10) + (sum % 10));

                    if (sum <= 9) { CardNum += sum; } else { CardNum += ((sum / 10) + (sum % 10)); }

                    return CardNum;

                case "m":
                    string CardNumm = MastercardPrefix;
                    long nm = 0;
                    long LongAuxm = 0;
                    long LongAux2m = 0;
                    long xm = 100000000000000;
                    long summ = 0;
                    Random randomm = new Random();

                    CardNumm += randomm.Next(100000000, 999999999);
                    CardNumm += randomm.Next(1000, 9999);

                    LongAuxm = Convert.ToInt64(CardNumm);

                    LongAux2m = LongAuxm;

                    for (int i = 0; i < CardNumm.Length; i++)
                    {
                        nm = LongAux2m / xm;
                        switch (i)
                        {
                            case 0:
                            case 2:
                            case 4:
                            case 6:
                            case 8:
                            case 10:
                            case 12:
                            case 14:
                                if (nm < 5) { summ += nm * 2; } else { nm = nm * 2; summ += ((nm / 10) + (nm % 10)); }
                                break;

                            case 1:
                            case 3:
                            case 5:
                            case 7: 
                            case 9:
                            case 11:
                            case 13:
                                summ += nm;
                                break;
                        }
                        LongAux2m = LongAux2m % xm;
                        xm = xm / 10;
                    }
                    summ = ((summ / 10) + (summ % 10));

                    if (summ <= 9) { CardNumm += summ; } else { CardNumm += ((summ / 10) + (summ % 10)); }

                    return CardNumm;

                default:
                    return "Unknown CardBrand";
            }
        }
    }
}