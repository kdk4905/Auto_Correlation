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
        public static List<string> r_Value_std = new List<string>();
        public static List<string> r_Value_bat = new List<string>();
        
        //Correation 연산을 위한 객체 생성
        public Auto_Correlation.Data_Calculator cal_data = new Auto_Correlation.Data_Calculator();

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

        //25.04.08 KDK
        #region Open 버튼 이벤트
        private void Open_Click(object sender, EventArgs e)
        {
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

                    //25.04.16 - KDK
                    //Correlation
                    //Data_cal 클래스에 std, bat 데이터 넣기
                    cal_data.string_r_Value_std = r_Value_std;
                    cal_data.string_r_Value_bat = r_Value_bat;

                    //string data -> double parse
                    cal_data.parse_list_double(cal_data.string_r_Value_std, cal_data.string_r_Value_bat);

                    //alpha, beta값 계산
                    cal_data.cal_alpha(cal_data.double_r_Value_std, cal_data.double_r_Value_bat);
                    cal_data.cal_beta(cal_data.double_r_Value_std, cal_data.double_r_Value_bat);
                    
                    //eta 기준값 생성
                    cal_data.make_bench_eta(cal_data.benchmark_eta);
                    
                    //eta 변화값 생성
                    cal_data.make_list_change_val_std(cal_data.double_r_Value_std, cal_data.double_r_eta_std, cal_data.benchmark_eta);

                    cal_data.cal_eta(cal_data.double_r_eta_std, cal_data.beta);

                    //메모장 생성
                    val_name = "ALPHA";
                    cor_to_note.content = cor_to_note.Make_cor_value(cal_data.alpha, cal_data.beta, cal_data.eta, val_name);

                    //Correation 메모장 파일 저장
                    cor_to_note.Save_CorrelatationFile(cor_to_note.content);

                    ;

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        #endregion
    }
}

