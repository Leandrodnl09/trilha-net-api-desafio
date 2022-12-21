using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_agendamento_de_tarefas.Context;
using TrilhaApiDesafio.Models;
using Microsoft.AspNetCore.Mvc;


namespace desafio_agendamento_de_tarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaContext context;

        public TarefaController(TarefaContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult Editar(Tarefa tarefa)
        {
            var t = this.context.Tarefas.Find(tarefa.Id);

            t.Titulo = tarefa.Titulo;
            t.Descricao = tarefa.Descricao;
            t.Data = tarefa.Data;
            t.Status = tarefa.Status;

            this.context.Update(t);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult ObterPorStatus(TipoStatus status)
        {
            if (status == TipoStatus.Tudo)
            {
                return View(this.context.Tarefas.ToList());
            }
            var c = this.context.Tarefas.Where(x => x.Status == status).ToList();
            return View(c);
        }

        [HttpPost]
        public ActionResult ObterPorData(DateTime data)
        {
            var c = this.context.Tarefas.Where(x => x.Data == data).ToList();
            return View(c);
        }

        [HttpPost]
        public ActionResult Index(string titulo)
        {
            var c = this.context.Tarefas.Where(x => x.Titulo.Contains(titulo)).ToList();
            return View(c);
        }

        [HttpPost]
        public ActionResult Criar(Tarefa tarefa)
        {
            this.context.Tarefas.Add(tarefa);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var t = this.context.Tarefas.Find(id);
            if (t == null)
                return RedirectToAction(nameof(Index));
            return View(t);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(this.context.Tarefas.ToList());
        }

        [HttpGet]
        public ActionResult ObterPorData()
        {
            return View(this.context.Tarefas.ToList());
        }

        [HttpGet]
        public ActionResult ObterPorStatus()
        {
            return View(this.context.Tarefas.ToList());
        }

        [HttpGet]
        public ActionResult ObterPorTitulo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Deletar(Tarefa tarefa)
        {
            var t = this.context.Tarefas.Find(tarefa.Id);
            this.context.Tarefas.Remove(t);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
