using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//25.04.08 KDK
//파일 오픈 다이얼로그 사용을 위한 참조 추가
using System.IO;
using System.Security;
//25.04.16 KDK
//Correation 연산을 위한 클래스 참조 추가
using Auto_Correlation;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using Auto_Correlation.Back;


namespace Auto_Correlation
{
    public partial class Main : Form
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        //std, bat list 생성
        public List<string> r_Value_std = new List<string>();
        public List<string> r_Value_bat = new List<string>();
        
        //Correation 연산을 위한 객체 생성
        public Auto_Correlation.Data_Calculator calNewData = new Auto_Correlation.Data_Calculator();
        public Auto_Correlation.Data_Calculator calOldData = new Auto_Correlation.Data_Calculator();

        //Correation 초기파일을 저장하기 위한 클래스 객체 생성
        public Correlation_Notepad cor_to_note = new Correlation_Notepad();

        public string val_name = "";

        public Main()
        {
            InitializeComponent();
        }

        //임시 - 읽어온 메모장 내용 확인
        private void SetText(string text)
        {
            txtBox_std.Text = text;
        }

        #region 이벤트
        //25.04.08 KDK
        #region Open 버튼 이벤트
        private void R_File_Open_Click(object sender, EventArgs e)
        {
            //리스트 클리어
            ResetListAll();

            //text box 클리어
            txtBox_std.Text = "";
            txtBox_bat.Text = "";

            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                string fileName = ofd.SafeFileName;
                string fileFullName = ofd.FileName;
                string filePath = fileFullName.Replace(fileName, "");

                try
                {
                    //%R data sr에 저장
                    var sr = new StreamReader(ofd.FileName);
                    
                    //std, bat 라인 읽어옴
                    string temp = sr.ReadLine();

                    //std, bat 이후 라인들을 읽어와 배열에 저장
                    string content = sr.ReadToEnd();
                    
                    int tabNumb = temp.IndexOf('\t');
                    int count = 0;
                    int chk_blank = 0;

                    string std = temp.Substring(0, tabNumb);
                    string bat = temp.Substring(tabNumb + 1);

                    //std, bat lbl에 표시
                    lbl_std.Text = std;
                    lbl_bat.Text = bat;

                    //%R data arr_data에 저장
                    string[] arr_data = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    
                    //std, bat list 만들기
                    foreach (string s in arr_data)
                    {
                        temp = "";
                        temp += s;
                        tabNumb = temp.IndexOf('\t');
                        
                        //""을 확인하기 위한 count 변수
                        chk_blank++;

                        if (s == "") { count = chk_blank; }
                        
                        if (temp != "" && tabNumb > 0 && tabNumb == 6)
                        {
                            r_Value_std.Add(s.Substring(1, tabNumb - 1));
                            r_Value_bat.Add(s.Substring(tabNumb + 2));
                        }
                    }

                    //체크변수 초기화
                    chk_blank = 0;
                    //std 데이터 출력
                    foreach (string s in r_Value_std)
                    {
                        chk_blank++;
                        if (chk_blank < count-1)
                        {
                            txtBox_std.Text += s.ToString() + "\r\n";
                        }
                        else
                        {
                            txtBox_std.Text += s.ToString();
                        }
                    }

                    //체크변수 초기화
                    chk_blank = 0;

                    //bat 데이터 출력
                    foreach (string s in r_Value_bat)
                    {
                        chk_blank++;
                        if (chk_blank < count - 1)
                        {
                            txtBox_bat.Text += s.ToString() + "\r\n";
                        }
                        else
                        {
                            txtBox_bat.Text += s.ToString();
                        }
                    }

                    ////25.04.16 - KDK
                    ////Correlation
                    ////Data_cal 클래스에 std, bat 데이터 넣기
                    //calNewData.string_r_Value_std = r_Value_std;
                    //calNewData.string_r_Value_bat = r_Value_bat;

                    ////string data -> double parse
                    //calNewData.parse_list_double(calNewData.string_r_Value_std, calNewData.string_r_Value_bat);

                    ////alpha, beta값 계산
                    //calNewData.cal_alpha(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);
                    //calNewData.cal_beta(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);
                    
                    ////eta 기준값 생성
                    //calNewData.make_bench_eta(calNewData.benchmark_eta);
                    
                    ////eta 변화값 생성
                    //calNewData.make_list_change_val_std(calNewData.double_r_Value_std, calNewData.double_r_eta_std, calNewData.benchmark_eta);

                    //calNewData.cal_eta(calNewData.double_r_eta_std, calNewData.beta);

                    ////메모장 생성
                    //val_name = "ALPHA";

                    //cor_to_note.content = Correlation_Content_NewAll(cor_to_note, calNewData);
                    ////Correation 메모장 파일 저장
                    //cor_to_note.Save_CorrelatationFile(cor_to_note.content);
                    //;

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        #endregion
        //25.04.17 KDK
        #region 종료 버튼 이벤트
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region 메서드
        
        public void OpenCorFile()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.SafeFileName;
                string fileFullName = ofd.FileName;
                string filePath = fileFullName.Replace(fileName, "");

                //corfile 리딩
                /* 구분자 \n
                 * 파일 전체 읽어서 변수에 담기
                 * 이후 list에 담기
                 * list에 담을때 [SCI_Coefficients] 기준
                 * SCI_ALPHA_Coefficients 부터 내용 담기
                 * 담을때 key value? 360 ~ 750
                 * SCI_LAMBDA_Coefficients 만나서 끝 값 ,0 넣으면 끝
                 */

                try
                {
                    var sr = new StreamReader(ofd.FileName);

                    //메모장 내용 불러오기
                    string content = sr.ReadToEnd();
                    content = content.Replace(" ", string.Empty);
                    string temp = "";
                    //%R data arr_data에 저장
                    string[] arr_data = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                    //메모장 내용 분류 및 알파, 베타, 에타 데이터 만들기
                    for (int i = 0; i < arr_data.Length; i++)
                    {
                        ;
                        string type = "";
                    
                        if (arr_data[i] == "[SCI_Coefficients]")
                        {
                            ;
                            //alpha
                            if (arr_data[i+3].Substring(0,22) == "SCI_ALPHA_Coefficients")
                            {
                                int count = 0;
                                type = "alpha";
                                temp = arr_data[i + 3].Substring(23);
                                string[] subWave = temp.Split(',');
                                foreach (string s in subWave) 
                                {
                                    calOldData.string_wave_data.Add(s);
                                }
                                //공백 삭제
                                calOldData.string_wave_data.Remove("");
                                
                                calOldData.parse_list_double(calOldData.string_wave_data, type);
                                calOldData.string_wave_data.Clear();
                                type = "";
                                temp = "";
                            }
                            //beta
                            if (arr_data[i + 4].Substring(0, 21) == "SCI_BETA_Coefficients")
                            {
                                type = "beta";
                                temp = arr_data[i + 4].Substring(22);
                                string[] subWave = temp.Split(',');
                                foreach (string s in subWave)
                                {
                                    calOldData.string_wave_data.Add(s);
                                }

                                calOldData.string_wave_data.Remove("");

                                calOldData.parse_list_double(calOldData.string_wave_data, type);
                                calOldData.string_wave_data.Clear();
                                type = "";
                                temp = "";
                            }
                            //eta
                            if (arr_data[i + 7].Substring(0, 20) == "SCI_ETA_Coefficients")
                            {
                                type = "eta";
                                temp = arr_data[i + 7].Substring(21);
                                string[] subWave = temp.Split(',');
                                foreach (string s in subWave)
                                {
                                    calOldData.string_wave_data.Add(s);
                                }

                                calOldData.string_wave_data.Remove("");
                                
                                calOldData.parse_list_double(calOldData.string_wave_data, type);
                                calOldData.string_wave_data.Clear();
                                type = "";
                                temp = "";
                                ;
                            }
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        //Correlation 메모장 내용 생성 메서드
        public string Correlation_Content_NewAll(Correlation_Notepad cor, Data_Calculator dtNew) 
        {
            string content = "";
            content = cor.Make_cor_value_allNew(dtNew.alpha, dtNew.beta, dtNew.eta);
            return content;
        }

        public string Correlation_Content_NewAlpha(Correlation_Notepad cor, Data_Calculator dtNew, Data_Calculator dtOld)
        {
            string content = "";
            content = cor.Make_cor_value_alpha(dtNew.alpha, dtOld.alpha, dtOld.beta, dtOld.eta);
            return content;
        }

        public string Correlation_Content_NewBeta(Correlation_Notepad cor, Data_Calculator dtNew, Data_Calculator dtOld)
        {
            string content = "";
            content = cor.Make_cor_value_beta(dtNew.beta, dtOld.alpha, dtOld.beta, dtOld.eta);
            return content;
        }

        public string Correlation_Content_NewEta(Correlation_Notepad cor, Data_Calculator dtNew, Data_Calculator dtOld)
        {
            string content = "";
            content = cor.Make_cor_value_eta(dtNew.eta, dtOld.alpha, dtOld.beta, dtOld.eta);
            return content;
        }
        #endregion

        private void btn_cor_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn = sender as System.Windows.Forms.Button;
            string type = "";
            type = btn.Tag.ToString();

            //25.04.16 - KDK
            //Correlation
            //Data_cal 클래스에 std, bat 데이터 넣기
            ;
            calNewData.string_r_Value_std = r_Value_std;
            calNewData.string_r_Value_bat = r_Value_bat;

            //string data -> double parse
            calNewData.parse_list_double(calNewData.string_r_Value_std, calNewData.string_r_Value_bat);

            if (type == "alpha")
            {
                ;
                //alpha값 계산
                calNewData.cal_alpha(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);

                cor_to_note.content = Correlation_Content_NewAlpha(cor_to_note, calNewData, calOldData);

                //Correation 메모장 파일 저장
                cor_to_note.Save_CorrelatationFile(cor_to_note.content);
            }

            if (type == "beta")
            {
                //beta값 계산
                calNewData.cal_beta(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);

                cor_to_note.content = Correlation_Content_NewBeta(cor_to_note, calNewData, calOldData);
                //Correation 메모장 파일 저장
                cor_to_note.Save_CorrelatationFile(cor_to_note.content);
            }

            if (type == "eta")
            {               
                //alpha, beta 값 계산
                calNewData.cal_alpha(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);
                calNewData.cal_beta(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);

                //eta 기준값 생성
                calNewData.make_bench_eta(calNewData.benchmark_eta);

                //eta 변화값 생성
                calNewData.make_list_change_val_std(calNewData.double_r_Value_std, calNewData.double_r_eta_std, calNewData.benchmark_eta);
                
                //eta 값 계산
                calNewData.cal_eta(calNewData.double_r_eta_std, calNewData.beta);

                cor_to_note.content = Correlation_Content_NewEta(cor_to_note, calNewData, calOldData);
                //Correation 메모장 파일 저장
                cor_to_note.Save_CorrelatationFile(cor_to_note.content);
            }

            if (type == "all")
            {
                //alpha, beta 값 계산
                calNewData.cal_alpha(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);
                calNewData.cal_beta(calNewData.double_r_Value_std, calNewData.double_r_Value_bat);

                //eta 기준값 생성
                calNewData.make_bench_eta(calNewData.benchmark_eta);

                //eta 변화값 생성
                calNewData.make_list_change_val_std(calNewData.double_r_Value_std, calNewData.double_r_eta_std, calNewData.benchmark_eta);
                
                //eta 값 계산
                calNewData.cal_eta(calNewData.double_r_eta_std, calNewData.beta);

                cor_to_note.content = Correlation_Content_NewAll(cor_to_note, calNewData);

                //Correation 메모장 파일 저장
                cor_to_note.Save_CorrelatationFile(cor_to_note.content);
            }
            //메모장 생성
            val_name = "ALPHA";
            ResetListNewData();
        }

        private void Btn_Open_Cor_Click(object sender, EventArgs e)
        {
            OpenCorFile();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            //reset
            System.Windows.Forms.Application.Restart();

        }

        //기존 cor 보정 데이터로 계속 진행하는 경우
        private void ResetListNewData() 
        {
            //%R값 | List | std, bat
            r_Value_std.Clear();
            r_Value_bat.Clear();

            calNewData.string_r_Value_std.Clear();
            calNewData.string_r_Value_bat.Clear();
            calNewData.double_r_Value_std.Clear();
            calNewData.double_r_Value_bat.Clear();

            //Cor Value | List | wave
            calNewData.alpha.Clear();

            calNewData.beta.Clear();

            calNewData.eta.Clear();
            calNewData.benchmark_eta.Clear();
            calNewData.double_r_eta_std.Clear();

            //메모장 | List | 
            cor_to_note.cor_value.Clear();
        }

        private void ResetListAll() 
        {
            //%R값 | List | std, bat
            r_Value_std.Clear();
            r_Value_bat.Clear();

            calNewData.string_r_Value_std.Clear();
            calNewData.string_r_Value_bat.Clear();
            calNewData.double_r_Value_std.Clear();
            calNewData.double_r_Value_bat.Clear();

            calOldData.string_r_Value_std.Clear();
            calOldData.string_r_Value_bat.Clear();
            calOldData.double_r_Value_std.Clear();
            calOldData.double_r_Value_bat.Clear();

            //Cor Value | List | wave
            calNewData.alpha.Clear();

            calNewData.beta.Clear();
            
            calNewData.eta.Clear();
            calNewData.benchmark_eta.Clear();
            calNewData.double_r_eta_std.Clear();

            calOldData.alpha.Clear();

            calOldData.beta.Clear();

            calOldData.eta.Clear();
            calOldData.benchmark_eta.Clear();
            calOldData.double_r_eta_std.Clear();

            //메모장 | List | 
            cor_to_note.cor_value.Clear();
        }
    }
}

