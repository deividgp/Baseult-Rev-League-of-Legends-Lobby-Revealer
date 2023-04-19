using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GetSummonerNames.Properties;

namespace GetSummonerNames
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            button1=new Button();
            button2=new Button();
            button3=new Button();
            label1=new Label();
            linkLabel1=new LinkLabel();
            linkLabel2=new LinkLabel();
            linkLabel3=new LinkLabel();
            linkLabel4=new LinkLabel();
            linkLabel5=new LinkLabel();
            button4=new Button();
            button5=new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor=Color.FromArgb(65, 65, 65);
            button1.FlatStyle=FlatStyle.Flat;
            button1.ForeColor=Color.Lime;
            button1.Location=new Point(20, 82);
            button1.Name="button1";
            button1.Size=new Size(109, 28);
            button1.TabIndex=0;
            button1.Text="GET NAMES";
            button1.UseVisualStyleBackColor=false;
            button1.Click+=Button1_Click;
            // 
            // button2
            // 
            button2.BackColor=Color.FromArgb(65, 65, 65);
            button2.Enabled=false;
            button2.FlatStyle=FlatStyle.Flat;
            button2.ForeColor=Color.Cyan;
            button2.Location=new Point(146, 82);
            button2.Name="button2";
            button2.Size=new Size(109, 28);
            button2.TabIndex=2;
            button2.Text="U.GG";
            button2.UseVisualStyleBackColor=false;
            button2.Click+=Button2_Click;
            // 
            // button3
            // 
            button3.BackColor=Color.FromArgb(65, 65, 65);
            button3.FlatStyle=FlatStyle.Flat;
            button3.ForeColor=Color.Red;
            button3.Location=new Point(272, 82);
            button3.Name="button3";
            button3.Size=new Size(109, 28);
            button3.TabIndex=3;
            button3.Text="DODGE";
            button3.UseVisualStyleBackColor=false;
            button3.Click+=Button3_Click;
            // 
            // label1
            // 
            label1.BackColor=Color.FromArgb(35, 35, 35);
            label1.BorderStyle=BorderStyle.FixedSingle;
            label1.ForeColor=Color.Lime;
            label1.Location=new Point(21, 122);
            label1.Name="label1";
            label1.Size=new Size(360, 27);
            label1.TabIndex=4;
            label1.Text="Join a Lobby and click on \"Get Names\"...";
            label1.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor=Color.FromArgb(35, 35, 35);
            linkLabel1.BorderStyle=BorderStyle.FixedSingle;
            linkLabel1.DisabledLinkColor=Color.DarkGray;
            linkLabel1.Enabled=false;
            linkLabel1.ForeColor=Color.Cyan;
            linkLabel1.LinkColor=Color.Aqua;
            linkLabel1.Location=new Point(27, 171);
            linkLabel1.Name="linkLabel1";
            linkLabel1.Size=new Size(349, 21);
            linkLabel1.TabIndex=5;
            linkLabel1.TabStop=true;
            linkLabel1.Text="PLAYER 1";
            linkLabel1.TextAlign=ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked+=LinkLabel_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.BackColor=Color.FromArgb(35, 35, 35);
            linkLabel2.BorderStyle=BorderStyle.FixedSingle;
            linkLabel2.DisabledLinkColor=Color.DarkGray;
            linkLabel2.Enabled=false;
            linkLabel2.ForeColor=Color.Cyan;
            linkLabel2.LinkColor=Color.Aqua;
            linkLabel2.Location=new Point(27, 203);
            linkLabel2.Name="linkLabel2";
            linkLabel2.Size=new Size(349, 21);
            linkLabel2.TabIndex=6;
            linkLabel2.TabStop=true;
            linkLabel2.Text="PLAYER 2";
            linkLabel2.TextAlign=ContentAlignment.MiddleCenter;
            linkLabel2.LinkClicked+=LinkLabel_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.BackColor=Color.FromArgb(35, 35, 35);
            linkLabel3.BorderStyle=BorderStyle.FixedSingle;
            linkLabel3.DisabledLinkColor=Color.DarkGray;
            linkLabel3.Enabled=false;
            linkLabel3.ForeColor=Color.Cyan;
            linkLabel3.LinkColor=Color.Aqua;
            linkLabel3.Location=new Point(27, 235);
            linkLabel3.Name="linkLabel3";
            linkLabel3.Size=new Size(349, 21);
            linkLabel3.TabIndex=7;
            linkLabel3.TabStop=true;
            linkLabel3.Text="PLAYER 3";
            linkLabel3.TextAlign=ContentAlignment.MiddleCenter;
            linkLabel3.LinkClicked+=LinkLabel_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.BackColor=Color.FromArgb(35, 35, 35);
            linkLabel4.BorderStyle=BorderStyle.FixedSingle;
            linkLabel4.DisabledLinkColor=Color.DarkGray;
            linkLabel4.Enabled=false;
            linkLabel4.ForeColor=Color.Cyan;
            linkLabel4.LinkColor=Color.Aqua;
            linkLabel4.Location=new Point(27, 267);
            linkLabel4.Name="linkLabel4";
            linkLabel4.Size=new Size(349, 21);
            linkLabel4.TabIndex=8;
            linkLabel4.TabStop=true;
            linkLabel4.Text="PLAYER 4";
            linkLabel4.TextAlign=ContentAlignment.MiddleCenter;
            linkLabel4.LinkClicked+=LinkLabel_LinkClicked;
            // 
            // linkLabel5
            // 
            linkLabel5.BackColor=Color.FromArgb(35, 35, 35);
            linkLabel5.BorderStyle=BorderStyle.FixedSingle;
            linkLabel5.DisabledLinkColor=Color.DarkGray;
            linkLabel5.Enabled=false;
            linkLabel5.ForeColor=Color.Cyan;
            linkLabel5.LinkColor=Color.Aqua;
            linkLabel5.Location=new Point(27, 299);
            linkLabel5.Name="linkLabel5";
            linkLabel5.Size=new Size(349, 21);
            linkLabel5.TabIndex=9;
            linkLabel5.TabStop=true;
            linkLabel5.Text="PLAYER 5";
            linkLabel5.TextAlign=ContentAlignment.MiddleCenter;
            linkLabel5.LinkClicked+=LinkLabel_LinkClicked;
            // 
            // button4
            // 
            button4.BackColor=Color.FromArgb(30, 30, 30);
            button4.FlatStyle=FlatStyle.Flat;
            button4.ForeColor=Color.FromArgb(255, 128, 0);
            button4.Location=new Point(20, 344);
            button4.Name="button4";
            button4.Size=new Size(169, 26);
            button4.TabIndex=10;
            button4.Text="MINIMIZE";
            button4.UseVisualStyleBackColor=false;
            button4.Click+=Button4_Click;
            // 
            // button5
            // 
            button5.BackColor=Color.FromArgb(30, 30, 30);
            button5.FlatStyle=FlatStyle.Flat;
            button5.ForeColor=Color.Red;
            button5.Location=new Point(212, 344);
            button5.Name="button5";
            button5.Size=new Size(169, 26);
            button5.TabIndex=11;
            button5.Text="CLOSE";
            button5.UseVisualStyleBackColor=false;
            button5.Click+=Button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.FromArgb(45, 45, 45);
            BackgroundImage=(Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout=ImageLayout.None;
            ClientSize=new Size(400, 384);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(linkLabel5);
            Controls.Add(linkLabel4);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle=FormBorderStyle.None;
            Name="Form1";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Lobby Names - Baseult";
            Load+=Form1_Load;
            MouseDown+=Form1_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
        private Button button4;
        private Button button5;
    }
}

