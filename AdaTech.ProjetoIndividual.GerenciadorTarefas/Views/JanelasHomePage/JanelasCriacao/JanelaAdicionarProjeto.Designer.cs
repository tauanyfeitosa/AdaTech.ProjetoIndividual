using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    partial class JanelaAdicionarProjeto
    {
        private TextBox txtNomeProjeto;
        private TextBox txtDescricaoProjeto;
        private DateTimePicker dateTimePickerDataInicio;
        private Button btnAdicionarProjeto;
        private Label lblMensagem;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtNomeProjeto = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDescricaoProjeto = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.dateTimePickerDataInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.btnAdicionarProjeto = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeProjeto
            // 
            this.txtNomeProjeto.Location = new System.Drawing.Point(361, 64);
            this.txtNomeProjeto.Name = "txtNomeProjeto";
            this.txtNomeProjeto.Size = new System.Drawing.Size(200, 20);
            this.txtNomeProjeto.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(230, 67);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(89, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome do Projeto:";
            // 
            // txtDescricaoProjeto
            // 
            this.txtDescricaoProjeto.Location = new System.Drawing.Point(361, 113);
            this.txtDescricaoProjeto.Multiline = true;
            this.txtDescricaoProjeto.Name = "txtDescricaoProjeto";
            this.txtDescricaoProjeto.Size = new System.Drawing.Size(200, 100);
            this.txtDescricaoProjeto.TabIndex = 2;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(230, 116);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(109, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "Descrição do Projeto:";
            // 
            // dateTimePickerDataInicio
            // 
            this.dateTimePickerDataInicio.Location = new System.Drawing.Point(361, 234);
            this.dateTimePickerDataInicio.MaxDate = new System.DateTime(2024, 1, 7, 15, 58, 10, 439);
            this.dateTimePickerDataInicio.Name = "dateTimePickerDataInicio";
            this.dateTimePickerDataInicio.Size = new System.Drawing.Size(215, 20);
            this.dateTimePickerDataInicio.TabIndex = 4;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(230, 241);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(78, 13);
            this.lblDataInicio.TabIndex = 5;
            this.lblDataInicio.Text = "Data de Início:";
            // 
            // btnAdicionarProjeto
            // 
            this.btnAdicionarProjeto.Location = new System.Drawing.Point(361, 311);
            this.btnAdicionarProjeto.Name = "btnAdicionarProjeto";
            this.btnAdicionarProjeto.Size = new System.Drawing.Size(119, 25);
            this.btnAdicionarProjeto.TabIndex = 6;
            this.btnAdicionarProjeto.Text = "Adicionar Projeto";
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(20, 260);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(0, 13);
            this.lblMensagem.TabIndex = 7;
            // 
            // JanelaAdicionarProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNomeProjeto);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtDescricaoProjeto);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.dateTimePickerDataInicio);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.btnAdicionarProjeto);
            this.Controls.Add(this.lblMensagem);
            this.Name = "JanelaAdicionarProjeto";
            this.Text = "JanelaAdicionarProjeto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNome;
        private Label lblDescricao;
        private Label lblDataInicio;
    }
}