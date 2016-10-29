using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TesteSqlite.Comunication;

namespace TesteSqlite.FrontEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Servicos.tarefaServico.Salvar(new Entity.Tarefa() { Ativo = true, Descricao = "Teste de tarefa 1", LogExecucao = "log exec", Status = false });
            Servicos.tarefaServico.Salvar(new Entity.Tarefa() { Ativo = true, Descricao = "Teste de tarefa 2", LogExecucao = "log exec", Status = false });
            Servicos.tarefaServico.Salvar(new Entity.Tarefa() { Ativo = true, Descricao = "Teste de tarefa 3", LogExecucao = "log exec", Status = false });


            foreach (var t in Servicos.tarefaServico.SelecionarTodos())
            {
                bsTarefa.Add(t);
            }
        }
    }
}
