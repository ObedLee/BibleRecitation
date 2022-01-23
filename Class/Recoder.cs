using NAudio.Wave;
using System;
using System.IO;

namespace BibleRecitation
{
    public class Recorder
    {

        WaveIn sourceStream;
        WaveFileWriter waveWriter;

        readonly String DirPath;
        readonly String FileName;
        readonly int InputDeviceIndex;

        public Recorder(int inputDeviceIndex, String dirPath, String fileName)
        {
            this.InputDeviceIndex = inputDeviceIndex;
            this.FileName = fileName;
            this.DirPath = dirPath;
        }

        public void StartRecording()
        {
            sourceStream = new WaveIn
            {
                DeviceNumber = this.InputDeviceIndex,
                WaveFormat =
                    new WaveFormat(16000, 1)
            };

            sourceStream.DataAvailable += this.SourceStreamDataAvailable;

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            waveWriter = new WaveFileWriter(DirPath+"\\"+FileName, sourceStream.WaveFormat);
            sourceStream.StartRecording();
        }

        public void SourceStreamDataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter == null) return;
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        public void RecordEnd()
        {
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (this.waveWriter == null)
            {
                return;
            }
            this.waveWriter.Dispose();
            this.waveWriter = null;

        }
    }
}
