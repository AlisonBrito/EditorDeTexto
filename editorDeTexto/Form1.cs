/*
Este trabalho foi feito para uma avaliação do curso de Desenvolvimento de Sistemas do Senai na matéria de Programação de Aplicativos.
Foi feito um editor de textos, com funções de salvar documentos em formatos de PDF, RTF e TXT, abrir outros documentos já salvos, imprimir, selecionar alinhamentos, 
fontes, negritos, sublinhados e itálico.

Nome: Alison Brito 
Versão: 0.1 
Data da última modificação: 26/11/2024
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace editorDeTexto
{
    public partial class Form1 : Form
    {
        PrintDialog printDialog = new PrintDialog();
        private object prntdlg1;
        private object prntdoc1;
        StringReader read = null;
        string text;
        public Form1()
        {
            InitializeComponent();
        }

        // PARTE ONDE SALVA ARQUIVOS COM SUA FUNÇÃO 
        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }
        private void salvarArquivo()
        {
            SaveFileDialog arquivo = new SaveFileDialog();
            arquivo.InitialDirectory = @"C:\Users\aliso\OneDrive\Desktop\editorDeTexto(TRABALHO)";
            arquivo.Filter = "Arquivos Ritch Text Format(rtf)|*.rtf|Portable Document Format(pdf)|*.pdf|Text(txt)|*.txt";

            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                if (arquivo.FileName.IndexOf(".") == -1)
                {
                    arquivo.FileName += ".rtf";
                }
                richTextBox1.SaveFile(arquivo.FileName);
            }
        }



        // PARTE PARA ABRIR ARQUIVOS 
        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\aliso\OneDrive\Desktop\editorDeTexto(TRABALHO)";
            dialog.Filter = "Arquivos Ritch Text Format(rtf)|*.rtf|Portable Document Format(pdf)|*.pdf|Text(txt)|*.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(dialog.FileName);
            }
        }



        // PARTE ONDE FAÇO MODIFICAÇÕES NOS TEXTOS 
        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fonte = new FontDialog();

            if (fonte.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fonte.Font;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;

            if (currentFont.Style.HasFlag(FontStyle.Bold))
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style & ~FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Bold);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;

            if (currentFont.Style.HasFlag(FontStyle.Underline))
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style & ~FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Underline);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;

            if (currentFont.Style.HasFlag(FontStyle.Italic))
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style & ~FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Italic);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog cor = new ColorDialog();

            if (cor.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = cor.Color;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }



        // PARTE ONDE ESTA FAZENDO IMPRESSÃO    
        private void impressao()
        {

            printDialog1.Document = printDocument1;

            text = this.richTextBox1.Text;
            read = new StringReader(text);

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }
        private void imprimirToolStripButton_Click(object sender, EventArgs e)
        {
            impressao();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Size = new Size(1515,700);
        }
    }
}
