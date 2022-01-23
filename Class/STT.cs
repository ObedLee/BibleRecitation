using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BibleRecitation
{
    class STT
    {
        readonly static private string kakao_api_url = "https://kakaoi-newtone-openapi.kakao.com/v1/recognize";
        readonly static private string rest_api_key = "1b2a6309702f43e52f69ef7cc80d79dc";
        readonly string wavFilePath;

        public STT(string wavFilePath)
        {
            this.wavFilePath = wavFilePath;
        }

        public string Run()
        {
            string responseText = string.Empty;
            string startText = "\"finalResult\",\"value\":\"";
            string endText = "\",\"nBest\":[{";
            string resultText = string.Empty;

            int startIndex = 0;
            int endIndex = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(kakao_api_url); // 해당 URL로 네트웍 생성
            request.Headers.Add("Authorization", rest_api_key); // 헤더에 옵션값을 추가
            request.ContentType = "application/octet-stream";// 콘텐츠타입 명시
            request.Method = "post"; // post로 보냄

            FileStream file = new FileStream(wavFilePath, FileMode.Open); // 보낼 파일을 열기

            try
            {
                byte[] byteDataParams = new byte[file.Length]; // 보낼파일의 크기만큼 바이트배열을 생성

                file.Read(byteDataParams, 0, byteDataParams.Length); // 파일을 읽어서 바이트배열에 데이터를 넣기

                request.ContentLength = byteDataParams.Length; // 네트웍으로 보낼 데이터 길이 명시

                using (Stream reqStream = request.GetRequestStream()) // 네트웍을 열어서 데이터를 보냄
                {
                    reqStream.Write(byteDataParams, 0, byteDataParams.Length); // 데이터 쓰기
                }

                using (WebResponse response = request.GetResponse()) // 보낸데이터를 기반으로 받기
                {
                    Stream stream = response.GetResponseStream(); // 받은 데이터를 스트림으로 쓰기
                    using (StreamReader sr = new StreamReader(stream)) // 스트림을 읽기 위해 리더를 열기
                    {
                        responseText = sr.ReadToEnd(); // 스트림의 내용을 읽어서 문자열로 반환
                    }
                }

                file.Close();
                file.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            

            startIndex = responseText.IndexOf(startText) + startText.Length;
            endIndex = responseText.IndexOf(endText);

            if (endIndex - startIndex > 0)
            {
                resultText = responseText.Substring(startIndex, endIndex - startIndex);
                return resultText; // 내용을 반환한다.
            }

            return string.Empty;
        }

    }
}
