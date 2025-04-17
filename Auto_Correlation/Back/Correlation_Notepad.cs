using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Correlation.Back
{
    public class Correlation_Notepad
    {
        //필드
        public string content = "";
        public List<double> cor_value = new List<double>();
        public string val_name = "";

        /* 필요한 내용
         * 리스트 3개 - alpha, beta, eta
         * 메모장 내용 만들기
         * 반복문 - 메모장 내용 +로 채우기
         * alpha > beta > 감마 > 델타 > 에타
         * > 람다 > 스핀 > 스펙스
         * alpha beta eta 제외 나머지 0 
         * 
         */
        public string Make_cor_value(List<double> alpha, List<double> beta, List<double> eta, string name) 
        {
            string form = "";
            string val_alpha = "";
            string val_beta = "";
            string val_eta = "";
            string val_gamma = "";
            string val_delta = "";
            string val_lamda = "";

            //ALPHA
            form = "SCI_ALPHA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 4개
            for (int i = 0; i < 4; i++)
            {
                form += "1," ;
            }

            //값 입력 - 400 ~ 700 nm 31개
            foreach (double val in alpha) 
            {
                form += val.ToString() + ",";
            }

            //초기값 만들기 - 710 ~ 740nm 4개 
            for (int i = 0; i < 4; i++)
            {
                form += "1,";
            }

            //750nm 1개
            form += "1";
            form += "\n";

            //alpha 값 완성
            val_alpha = form;
            form = "";
            
            //BETA
            form = "SCI_BETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 
            for (int i = 0; i < 4; i++)
            {
                form += "1,";
            }

            //값 입력 - 400 ~ 700 nm
            foreach (double val in beta)
            {
                form += val.ToString() + ",";
            }

            //초기값 만들기 - 710 ~ 740nm 
            for (int i = 0; i < 4; i++)
            {
                form += "1,";
            }

            //750nm
            form += "1";
            form += "\n";
            
            //beta 값 완성
            val_beta = form;
            form = "";
            
            //GAMMA
            form = "SCI_GAMMA_Coefficients=";
            //초기값 만들기 - 360 ~ 740nm 
            for (int i = 0; i < 39; i++)
            {
                form += "0,";
            }

            //750nm
            form += "0";
            form += "\n";

            //gamma 값 완성
            val_gamma = form;
            form = "";

            //DELTA
            form = "SCI_DELTA_Coefficients=";
            //초기값 만들기 - 360 ~ 740nm 
            for (int i = 0; i < 39; i++)
            {
                form += "0,";
            }

            //750nm
            form += "0";
            form += "\n";

            //DELTA 값 완성
            val_delta = form;
            form = "";

            //ETA
            form = "SCI_ETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 
            for (int i = 0; i < 4; i++)
            {
                form += "1,";
            }

            //값 입력 - 400 ~ 700 nm
            foreach (double val in eta)
            {
                form += val.ToString() + ",";
            }

            //초기값 만들기 - 710 ~ 740nm 
            for (int i = 0; i < 4; i++)
            {
                form += "1,";
            }

            //750nm
            form += "1";
            form += "\n";

            //ETA 값 완성
            val_eta = form;
            form = "";

            //LAMBDA
            form = "SCI_LAMBDA_Coefficients=";
            //초기값 만들기 - 360 ~ 740nm 
            for (int i = 0; i < 39; i++)
            {
                form += "0,";
            }

            //750nm
            form += "0";
            form += "\n";

            //LAMBDA 값 완성
            val_lamda = form;
            form = "";

            return form = val_alpha + val_beta + val_gamma + val_delta + val_eta + val_lamda;
        }

        //메서드
        public void Save_CorrelatationFile(string cor_val) 
        {
            //폴더 체크
            string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //string folderPath = @"C:\Users\" + pcName + "Desktop" + "Correaltion";

            // 2. 바탕화면 경로에 내가 원하는 폴더 확인&생성 하기
            string saveFolder_path = desktop_path + "//Correlation";

            DirectoryInfo directoryInfo = new DirectoryInfo(saveFolder_path);
            if (directoryInfo.Exists != true)
            {
                directoryInfo.Create();
            }
            string filePath = saveFolder_path + "//Correlation.txt";
            System.IO.File.WriteAllText(filePath, cor_val);
        }
    }
}
