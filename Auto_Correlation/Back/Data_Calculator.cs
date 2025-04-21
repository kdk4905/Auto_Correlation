using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Correlation
{
    public class Data_Calculator
    {
        //public readonly struct KeyValuePair<TKey, TValue> { }

        //필드
        
        //std, bat string 데이터 저장 리스트
        public List<string> string_r_Value_std = new List<string>();
        public List<string> string_r_Value_bat = new List<string>();

        //cor File string 데이터 저장 리스트
        public List<string> string_wave_data = new List<string>();

        //std, bat float 데이터 저장 리스트
        public List<double> double_r_Value_std  = new List<double>();
        public List <double> double_r_Value_bat = new List<double> ();
        
        //result - alpha, beta, eta
        public List <double> alpha = new List<double> ();
        public List<double> beta = new List<double>();
        public List<double> eta = new List<double>();

        //eta cal data
        public Dictionary<double, double> benchmark_eta = new Dictionary<double, double> ();
        
        //std change val List
        public List<double> double_r_eta_std = new List<double> ();

        public void make_bench_eta(Dictionary<double, double> dic) 
        {
            double val = 0;
            #region 반사율 0~5
            //반사율 0~5
            for (int i = 0; i <= 5; i++)
            {
                val = 0.01;
                dic.Add(i, val);
            }
            #endregion
            #region 반사율 6~10
            //반사율 6~10
            for (int i = 6; i <= 10; i++)
            {
                val = 0.02;
                dic.Add(i, val);
            }
            #endregion
            #region 반사율 11~15
            //반사율 11~15
            for (int i = 11; i <= 15; i++)
            {
                val = 0.03;
                dic.Add(i, val);
            }
            #endregion
            #region 반사율 16~20
            //반사율 16~20
            for (int i = 16; i <= 20; i++)
            {
                val = 0.04;
                dic.Add(i, val);
            }
            #endregion
            #region 반사율 21~29
            //반사율 21~23
            for (int i = 21; i <= 23; i++)
            {
                val = 0.05;
                dic.Add(i, val);
            }

            //반사율 24~29
            for (int i = 24; i <= 29; i++)
            {
                val = 0.06;
                
                if (i < 26)
                {
                    dic.Add(i, val);
                }

                //반사율 26
                else if (i == 26)
                {
                    val = 0.07;
                    dic.Add(i, val);
                }
                //반사율 27
                else if (i == 27)
                {
                    val = 0.08;
                    dic.Add(i, val);
                }
                //반사율 28
                else if (i == 28) 
                {
                    val = 0.09;
                    dic.Add(i, val);
                }
                //반사율 29
                else if (i == 29)
                {
                    val = 0.1;
                    dic.Add(i, val);
                }
            }
            #endregion
            #region 반사율 30~39
            //반사율 30~39
            for (int i = 30; i <= 39; i++)
            {
                val = 0.12;
                
                //반사율 30
                if (i == 30)
                {
                    dic.Add(i, val);
                }

                //반사율 31~33
                else if (i > 30 && i < 34)
                {
                    val = 0.13;
                    dic.Add(i, val);
                }

                //반사율 34~35
                else if (i > 33 && i < 36)
                {
                    val = 0.14;
                    dic.Add(i, val);
                }

                //반사율 36~37
                else if (i > 35 && i < 38)
                {
                    val = 0.15;
                    dic.Add(i, val);
                }

                //반사율 38~39
                else if (i == 38)
                {
                    val = 0.16;
                    dic.Add(i, val);
                }

                //반사율 39
                else if (i == 39)
                {
                    val = 0.17;
                    dic.Add(i, val);
                }
            }
            #endregion
            #region 반사율 40~49
            //반사율 40~49
            for (int i = 40; i <= 49; i++)
            {
                val = 0.17;

                //반사율 40
                if (i == 40)
                {
                    dic.Add(i, val);
                }

                //반사율 41
                if (i == 41)
                {
                    val = 0.18;
                    dic.Add(i, val);
                }

                //반사율 42
                if (i == 42)
                {
                    val = 0.19;
                    dic.Add(i, val);
                }

                //반사율 43
                if (i == 43)
                {
                    val = 0.2;
                    dic.Add(i, val);
                }

                //반사율 44~45
                if (i > 43 && i < 46)
                {
                    val = 0.21;
                    dic.Add(i, val);
                }

                //반사율 46
                if (i == 46)
                {
                    val = 0.22;
                    dic.Add(i, val);
                }

                //반사율 47
                if (i == 47)
                {
                    val = 0.23;
                    dic.Add(i, val);
                }

                //반사율 48
                if (i == 48)
                {
                    val = 0.24;
                    dic.Add(i, val);
                }

                //반사율 49
                if (i == 49)
                {
                    val = 0.25;
                    dic.Add(i, val);
                }
            }
            #endregion
            #region 반사율 50~59
            //반사율 50~59
            val = 0.25;
            for (int i = 50; i <= 59; i++)
            {
                val += 0.01;
                dic.Add(i, Math.Round(val,2));
            }
            #endregion
            #region 반사율 60~69
            //반사율 60~69
            val = 0.35;
            for (int i = 60; i <= 69; i++)
            {
                val += 0.01;
                dic.Add(i, Math.Round(val, 2));
            }
            #endregion
            #region 반사율 70~79
            //반사율 70~79
            val = 0.45;
            for (int i = 70; i <= 79; i++)
            {
                val += 0.01;
                dic.Add(i, Math.Round(val, 2));
            }
            #endregion
            #region 반사율 80~89
            //반사율 80~89
            val = 0.55;
            for (int i = 80; i <= 89; i++)
            {
                val += 0.01;
                dic.Add(i, Math.Round(val, 2));
            }
            #endregion
            #region 반사율 90~99
            //반사율 90~99
            val = 0.65;
            for (int i = 90; i <= 99; i++)
            {
                val += 0.01;
                dic.Add(i, Math.Round(val, 2));
            }
            #endregion
        }

        //메서드

        //eta - 변화값 리스트 생성
        public void make_list_change_val_std(List<double> std, List<double> change_std, Dictionary<double,double> eta) 
        {
            //std 소수점 자른 값 저장을 위한 list 생성 
            List<double> temp = new List<double>();
            List<string> cut_std_value = new List<string>();
            
            //std 소수점 제거
            foreach (double d in std) 
            {
                cut_std_value.Add(d.ToString().Substring(0,2));
            }

            //std 소수점 자른 값 temp에 저장
            foreach (string d in cut_std_value) 
            {
                temp.Add(double.Parse(d));
            }

            //변화값 리스트 생성
            for (int i = 0; i < temp.Count; i++) 
            {
                for (int j = 0; j < eta.Count; j++) 
                {
                    if (temp[i] == j)
                    {
                        change_std.Add(eta[j]);
                    }
                }
            }
        }

        public void parse_list_double(List<string> wave, string type)
        {
            for (int i = 0; i < wave.Count; i++)
            {
                if (type == "alpha") 
                {
                    alpha.Add(double.Parse(wave[i]));
                }

                if (type == "beta")
                {
                    beta.Add(double.Parse(wave[i]));
                }

                if (type == "eta")
                {
                    eta.Add(double.Parse(wave[i]));
                }
            }
        }

        public void parse_list_double(List<string> std, List<string> bat) 
        {
            for (int i = 0; i < std.Count; i++) 
            {
                double_r_Value_std.Add(double.Parse(std[i]));
                double_r_Value_bat.Add(double.Parse(bat[i]));
            }
        }

        public void parse_list_string(List<double> std, List<double> bat)
        {
            for (int i = 0; i < std.Count; i++)
            {
                string_r_Value_std[i] = std[i].ToString();
                string_r_Value_bat[i] = bat[i].ToString();
            }
        }

        public void cal_alpha(List<double> std, List<double> bat) 
        {
            
            for (int i = 0; i < std.Count; i++)
            {
                double val = Math.Round(std[i] / bat[i] , 8);
                alpha.Add(val);
            }
        }

        public void cal_beta(List<double> std, List<double> bat)
        {
            for (int i = 0; i < std.Count; i++)
            {
                double val = Math.Round(std[i] - bat[i], 8);
                beta.Add(val);
            }
        }

        public void cal_eta(List<double> eta_std, List<double> bat)
        {
            double multi = 0;
            double result = 0;
            multi = -0.0001;

            for (int i = 0; i < eta_std.Count; i++)
            {
                result = (multi * bat[i]) / eta_std[i];
                eta.Add(result);
            }
        }
    }
}
