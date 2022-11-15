using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebAspNet.Services;
using SaleWebAspNet.Models;
using SaleWebAspNet.Models.ViewModels;
using SaleWebAspNet.Services.Exceptions;
using System.Diagnostics;

namespace SaleWebAspNet.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //Cria uma lista de departamentos através do serviço de departamentos.
        //Instancia uma classe de FormView trazendo os departamentos encontrados.
        //Mostra na nossa View o viewModel criado.
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        //Implementa uma ação create retornando o serviço de seller
        //Onde vai redirecionar para a página do Index utilizando o método POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        //Cria uma ação de Delete para verificar se há um id do objeto ou não.
        //Retornando um erro e caso encontre ele mostrará o objeto na tela.
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided"});
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        //Validação com o método post para deletar o id de um vendedor.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        //Controlador para editar as informações do vendedor
        //Verificando se há ou não um id do objeto definido e listando as listas de departamento.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel {Seller = obj, Departments = departments };
            return View(viewModel);
        }

        //Criando o controlador edit com o método POST para que valide a requisição.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        //Criando uma ação de erro para mostrar uma mensagem de erro na requisição.
        //Mostrando também o ID interno através de um HttpContext e mostrar na tela.
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
