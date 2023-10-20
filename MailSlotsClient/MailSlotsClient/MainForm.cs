using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MailSlotsClient
{
    public partial class MainForm : Form
    {
        private string UserName {  get; set; }
        private Int32 HandleMailSlot {  get; set; }
        private Int32 ClientHandleMailSlot { get; set; }
        private string MailSlotName { get; set; }
        private Thread t;                       // поток для обслуживания мэйлслота
        private bool _continue = true;          // флаг, указывающий продолжается ли работа с мэйлслотом
        public MainForm(string userName, string handleMailSlotName)
        {
            InitializeComponent();
            UserName = userName;
            HandleMailSlot = DIS.Import.CreateFile($"\\\\*\\mailslot\\{handleMailSlotName}", DIS.Types.EFileAccess.GenericWrite, DIS.Types.EFileShare.Read, 0, DIS.Types.ECreationDisposition.OpenExisting, 0, 0); ;
            MailSlotName = $"\\\\.\\mailslot\\{UserName}";
            ClientHandleMailSlot = DIS.Import.CreateMailslot(MailSlotName, 0, DIS.Types.MAILSLOT_WAIT_FOREVER, 0);

            Thread t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            uint BytesWritten = 0;  // количество реально записанных в мэйлслот байт
            byte[] buff = Encoding.Unicode.GetBytes(UserName + " >> " + tbMessage.Text);    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт

            DIS.Import.WriteFile(HandleMailSlot, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);     // выполняем запись последовательности байт в мэйлслот
        }

        private void ReceiveMessage()
        {
            string msg = "";            // прочитанное сообщение
            int MailslotSize = 0;       // максимальный размер сообщения
            int lpNextSize = 0;         // размер следующего сообщения
            int MessageCount = 0;       // количество сообщений в мэйлслоте
            uint realBytesReaded = 0;   // количество реально прочитанных из мэйлслота байтов

            // входим в бесконечный цикл работы с мэйлслотом
            while (_continue)
            {
                // получаем информацию о состоянии мэйлслота
                DIS.Import.GetMailslotInfo(ClientHandleMailSlot, MailslotSize, ref lpNextSize, ref MessageCount, 0);

                // если есть сообщения в мэйлслоте, то обрабатываем каждое из них
                if (MessageCount > 0)
                    for (int i = 0; i < MessageCount; i++)
                    {
                        byte[] buff = new byte[1024];                           // буфер прочитанных из мэйлслота байтов
                        DIS.Import.FlushFileBuffers(ClientHandleMailSlot);      // "принудительная" запись данных, расположенные в буфере операционной системы, в файл мэйлслота
                        DIS.Import.ReadFile(ClientHandleMailSlot, buff, 1024, ref realBytesReaded, 0);      // считываем последовательность байтов из мэйлслота в буфер buff
                        msg = Encoding.Unicode.GetString(buff);                 // выполняем преобразование байтов в последовательность символов
                        string[] system_msg = msg.Split('|');
                        richTextBox.Invoke((MethodInvoker)delegate
                        {
                            if (msg != "")
                                richTextBox.Text += "\n >> " + msg + " \n";     // выводим полученное сообщение на форму
                        });
                        Thread.Sleep(500);                                      // приостанавливаем работу потока перед тем, как приcтупить к обслуживанию очередного клиента
                    }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DIS.Import.CloseHandle(ClientHandleMailSlot);     // закрываем дескриптор мэйлслота
        }
    }
}
