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
        public string Make_cor_value_alpha(List<double> newAlpha, List<double> oldAlpha,  List<double> oldBeta, List<double> oldEta) 
        {
            string form = "";
            string val_alpha = "";
            string val_beta = "";
            string val_eta = "";
            string val_gamma = "";
            string val_delta = "";
            string val_lamda = "";

            //값 계산 리스트 temp
            List<double> temp = new List<double>();
            temp.Clear();

            //ALPHA
            form = "SCI_ALPHA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 4개
            for (int i = 0; i < 4; i++)
            {
                temp.Add(1);
            }

            //값 입력 - 400 ~ 700 nm 31개
            foreach (double val in newAlpha)
            {
                temp.Add(val);
            }
            //newAlpha 초기화
            newAlpha.Clear();

            //초기값 만들기 - 710 ~ 740nm 4개 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(1);
            }

            //750nm 1개
            temp.Add(1);

            //새로운 알파 보정값 연산
            for (int i = 0; i < temp.Count; i++)
            {
                newAlpha.Add(temp[i] * oldAlpha[i]);
            }

            //새로운 알파 보정값 문자로 만들기
            //                  40             - 2 = 38 //360 ~ 740 
            for (int i = 0; i < newAlpha.Count; i++)
            {
                form += newAlpha[i].ToString() + ","/* + "[" + (i + 1) + "]"*/;
            }
            ////               40             - 1 = 39 //750
            //form += newAlpha[newAlpha.Count - 1].ToString();
            
            //문자열 정리 - 끝문자 ',' 제거 및 엔터 처리
            form += "\r\n";

            //alpha 값 완성
            val_alpha = form;
            form = "";

            //BETA
            int count = 0;
            form = "SCI_BETA_Coefficients=";
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldBeta)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            count = 0;
            form += "\r\n";
            
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
            form += "\r\n";

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
            form += "\r\n";

            //DELTA 값 완성
            val_delta = form;
            form = "";

            //ETA
            form = "SCI_ETA_Coefficients=";
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldEta)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            count = 0;
            form += "\r\n";

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
            form += "\r\n";

            //LAMBDA 값 완성
            val_lamda = form;
            form = "";

            return form = val_alpha + val_beta + val_gamma + val_delta + val_eta + val_lamda;
        }

        public string Make_cor_value_beta(List<double> newBeta, List<double> oldAlpha, List<double> oldBeta, List<double> oldEta)
        {
            string form = "";
            string val_alpha = "";
            string val_beta = "";
            string val_eta = "";
            string val_gamma = "";
            string val_delta = "";
            string val_lamda = "";

            //디버깅 변수
            int count = 0;

            //값 계산 리스트 temp
            List<double> temp = new List<double>();
            temp.Clear();

            //Alpha
            form = "SCI_Alpha_Coefficients=";
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldAlpha)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            form += "\r\n";

            //alpha 값 완성
            val_alpha = form;
            form = "";

            //BETA
            form = "SCI_BETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 4개
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //값 입력 - 400 ~ 700 nm 31개
            foreach (double val in newBeta)
            {
                temp.Add(val);
            }
            //newBeta 초기화
            newBeta.Clear();

            //초기값 만들기 - 710 ~ 740nm 4개 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //750nm 1개
            temp.Add(0);

            //새로운 베타 보정값 연산
            for (int i = 0; i < temp.Count; i++)
            {
                newBeta.Add(temp[i] + oldBeta[i]);
            }

            //새로운 베타 보정값 문자로 만들기
            //                  40             - 2 = 38 //360 ~ 740 
            for (int i = 0; i < newBeta.Count; i++)
            {
                form += newBeta[i].ToString() + ","/* + "[" + (i + 1) + "]"*/;
            }
            //               40             - 1 = 39 //750
            //form += newBeta[newBeta.Count - 1].ToString();

            //문자열 정리 - 끝문자 ',' 제거 및 엔터 처리
            form += "\r\n";

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
            form += "\r\n";

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
            form += "\r\n";

            //DELTA 값 완성
            val_delta = form;
            form = "";

            //ETA
            form = "SCI_ETA_Coefficients=";
            count = 0;
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldEta)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            form += "\r\n";

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
            form += "\r\n";

            //LAMBDA 값 완성
            val_lamda = form;
            form = "";

            return form = val_alpha + val_beta + val_gamma + val_delta + val_eta + val_lamda;
        }

        public string Make_cor_value_eta(List<double> newEta, List<double> oldAlpha, List<double> oldBeta, List<double> oldEta)
        {
            ;
            string form = "";
            string val_alpha = "";
            string val_beta = "";
            string val_eta = "";
            string val_gamma = "";
            string val_delta = "";
            string val_lamda = "";

            //디버그 변수
            int count = 0;

            //값 계산 리스트 temp
            List<double> temp = new List<double>();
            temp.Clear();

            //Eta
            form = "SCI_ETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 4개
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //값 입력 - 400 ~ 700 nm 31개
            foreach (double val in newEta)
            {
                temp.Add(val);
            }
            //newEta 초기화
            newEta.Clear();

            //초기값 만들기 - 710 ~ 740nm 4개 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //750nm 1개
            temp.Add(0);

            //새로운 에타 보정값 연산
            for (int i = 0; i < temp.Count; i++)
            {
                newEta.Add(temp[i] + oldEta[i]);
            }

            //새로운 에타 보정값 문자로 만들기
            //                  40             - 2 = 38 //360 ~ 740 
            for (int i = 0; i < newEta.Count; i++)
            {
                form += newEta[i].ToString() + ","/* + "[" + (i+1) + "]"*/;
            }
            ////               40             - 1 = 39 //750
            //form += newEta[newEta.Count - 1].ToString();

            //문자열 정리 - 끝문자 ',' 제거 및 엔터 처리
            form += "\r\n";

            //eta 값 완성
            val_eta = form;
            form = "";

            //ALPHA
            form = "SCI_ALPHA_Coefficients=";
            
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldAlpha)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            form += "\r\n";

            //alpha 값 완성
            val_alpha = form;
            form = "";

            //BETA
            form = "SCI_BETA_Coefficients=";
            count = 0;
            //값 입력 - 360 ~ 750 nm
            foreach (double val in oldBeta)
            {
                count++;
                form += val.ToString() + ","/* + "[" + count + "]"*/;
            }
            form += "\r\n";

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
            form += "\r\n";

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
            form += "\r\n";

            //DELTA 값 완성
            val_delta = form;
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
            form += "\r\n";

            //LAMBDA 값 완성
            val_lamda = form;
            
            form = "";

            return form = val_alpha + val_beta + val_gamma + val_delta + val_eta + val_lamda;
        }

        public string Make_cor_value_allNew(List<double> newAlpha, List<double> newBeta, List<double> newEta) 
        {
            string form = "";
            string val_alpha = "";
            string val_beta = "";
            string val_eta = "";
            string val_gamma = "";
            string val_delta = "";
            string val_lamda = "";

            //디버그 변수 선언
            int count = 0;

            //값 계산 리스트 temp
            List<double> temp = new List<double>();
            temp.Clear();

            //ALPHA
            form = "SCI_ALPHA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 4개
            for (int i = 0; i < 4; i++)
            {
                temp.Add(1);
            }

            //값 입력 - 400 ~ 700 nm 31개
            foreach (double val in newAlpha)
            {
                temp.Add(val);
            }

            //초기값 만들기 - 710 ~ 740nm 4개 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(1);
            }

            //750nm 1개
            temp.Add(1);

            //새로운 알파 보정값 문자로 만들기
            for (int i = 0; i < temp.Count; i++)
            {
                form += temp[i].ToString() + ","/* + "[" + (i+1) + "]"*/;
            }

            temp.Clear();
            form += "\r\n";

            //alpha 값 완성
            val_alpha = form;
            form = "";

            //BETA
            form = "SCI_BETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //값 입력 - 400 ~ 700 nm
            foreach (double val in newBeta)
            {
                temp.Add(val);
            }

            //초기값 만들기 - 710 ~ 740nm 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //750nm
            temp.Add(0);

            //새로운 베타 보정값 문자로 만들기
            for (int i = 0; i < temp.Count; i++)
            {
                form += temp[i].ToString() + ","/* + "[" + (i + 1) + "]"*/;
            }

            temp.Clear();
            form += "\r\n";

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
            form += "\r\n";

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
            form += "\r\n";

            //DELTA 값 완성
            val_delta = form;
            form = "";

            //ETA
            form = "SCI_ETA_Coefficients=";
            //초기값 만들기 - 360 ~ 390nm 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //값 입력 - 400 ~ 700 nm
            foreach (double val in newEta)
            {
                 temp.Add(val);
            }

            //초기값 만들기 - 710 ~ 740nm 
            for (int i = 0; i < 4; i++)
            {
                temp.Add(0);
            }

            //750nm
            temp.Add(0);

            //새로운 에타 보정값 문자로 만들기
            for (int i = 0; i < temp.Count; i++)
            {
                form += temp[i].ToString() + ","/* + "[" + (i + 1) + "]"*/;
            }

            temp.Clear();
            form += "\r\n";

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
            form += "\r\n";

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
