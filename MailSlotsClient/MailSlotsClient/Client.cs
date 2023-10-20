﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MailSlotsClient;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private Int32 HandleMailSlot;   // дескриптор мэйлслота
        private string UserName;

        // конструктор формы
        public frmMain()
        {
            InitializeComponent();
            this.Text += "     " + Dns.GetHostName();   // выводим имя текущей машины в заголовок формы
        }

        // присоединение к мэйлслоту
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // открываем мэйлслот, имя которого указано в поле tbMailSlot
                HandleMailSlot = DIS.Import.CreateFile($"\\\\*\\mailslot\\{tbMailSlot.Text}", DIS.Types.EFileAccess.GenericWrite, DIS.Types.EFileShare.Read, 0, DIS.Types.ECreationDisposition.OpenExisting, 0, 0);
                if (HandleMailSlot != -1)
                {
                    uint BytesWritten = 0;  // количество реально записанных в мэйлслот байт
                    byte[] buff = Encoding.Unicode.GetBytes(UserName + "|system_message" );    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт

                    DIS.Import.WriteFile(HandleMailSlot, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);     // выполняем запись последовательности байт в мэйлсл
                    DIS.Import.CloseHandle(HandleMailSlot);
                    MainForm Mf = new MainForm(UserName, tbMailSlot.Text);
                    Mf.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
        }

        // отправка сообщения
        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    uint BytesWritten = 0;  // количество реально записанных в мэйлслот байт
        //    byte[] buff = Encoding.Unicode.GetBytes(UserName + " >> " + tbMessage.Text);    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт

        //    DIS.Import.WriteFile(HandleMailSlot, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);     // выполняем запись последовательности байт в мэйлслот
        //}

        //private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DIS.Import.CloseHandle(HandleMailSlot);     // закрываем дескриптор мэйлслота
        //}

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            UserName = textBoxName.Text;
        }
    }
}