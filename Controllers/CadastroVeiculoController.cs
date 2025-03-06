using Microsoft.AspNetCore.Mvc;
using STI_Entrevista_03_03_2025.CQRS.Commands;
using STI_Entrevista_03_03_2025.CQRS.DTOs;
using STI_Entrevista_03_03_2025.CQRS.Interfaces;
using STI_Entrevista_03_03_2025.CQRS.Queries;

namespace STI_Entrevista_03_03_2025.Controllers
{
    public class CadastroVeiculoController(
        ICommandResultHandler<CreateCadastroVeiculoCommand, CadastroVeiculoDto> createHandler,
        ICommandHandler<UpdateCadastroVeiculoCommand> updateHandler,
        ICommandHandler<DeleteCadastroVeiculoCommand> deleteHandler,
        IQueryHandler<GetCadastroVeiculoByIdQuery, CadastroVeiculoDto> getByIdHandler,
        IQueryHandler<GetAllCadastroVeiculosQuery, IEnumerable<CadastroVeiculoDto>> getAllHandler,
        IConfiguration configuration) : Controller
    {
        private readonly ICommandResultHandler<CreateCadastroVeiculoCommand, CadastroVeiculoDto> _createHandler = createHandler;
        private readonly ICommandHandler<UpdateCadastroVeiculoCommand> _updateHandler = updateHandler;
        private readonly ICommandHandler<DeleteCadastroVeiculoCommand> _deleteHandler = deleteHandler;
        private readonly IQueryHandler<GetCadastroVeiculoByIdQuery, CadastroVeiculoDto> _getByIdHandler = getByIdHandler;
        private readonly IQueryHandler<GetAllCadastroVeiculosQuery, IEnumerable<CadastroVeiculoDto>> _getAllHandler = getAllHandler;
        private readonly IConfiguration configuration = configuration;

        #region Actions

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
            ViewData["DbContext"] = configuration["DbContext"];

            return View(await _getAllHandler.Handle(GetAllCadastroVeiculosQuery.GET_ALL_CADASTRO_VEICULOS_QUERY));
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVeiculo = await GetCadastroVeiculo(id.Value);
            if (cadastroVeiculo == null)
            {
                return NotFound();
            }

            return View(cadastroVeiculo);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CadastroVeiculoDto command)
        {
            if (ModelState.IsValid)
            {
                var result = await _createHandler.HandleResult(new CreateCadastroVeiculoCommand
                {
                    Placa = command.Placa,
                    Marca = command.Marca,
                    Modelo = command.Modelo,
                    Cor = command.Cor,
                    Porte = command.Porte,
                    TipoDeCarga = command.TipoDeCarga,
                    Chassis = command.Chassis
                });

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVeiculo = await GetCadastroVeiculo(id.Value);

            if (cadastroVeiculo == null)
            {
                return NotFound();
            }

            return View(cadastroVeiculo);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] CadastroVeiculoDto cadastroVeiculo)
        {
            if (id != cadastroVeiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _updateHandler.Handle(new UpdateCadastroVeiculoCommand
                    {
                        Id = cadastroVeiculo.Id,
                        Placa = cadastroVeiculo.Placa,
                        Marca = cadastroVeiculo.Marca,
                        Modelo = cadastroVeiculo.Modelo,
                        Cor = cadastroVeiculo.Cor,
                        Porte = cadastroVeiculo.Porte,
                        TipoDeCarga = cadastroVeiculo.TipoDeCarga,
                        Chassis = cadastroVeiculo.Chassis
                    });
                }
                catch (Exception)
                {
                    if (!CadastroVeiculoExists(cadastroVeiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(cadastroVeiculo);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVeiculo = await GetCadastroVeiculo(id.Value);
            if (cadastroVeiculo == null)
            {
                return NotFound();
            }

            return View(cadastroVeiculo);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroVeiculo = await GetCadastroVeiculo(id);
            if (cadastroVeiculo != null)
            {
                await _deleteHandler.Handle(DeleteCadastroVeiculoCommand.NewDeleteCadastroVeiculoCommand(id));
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Helpers

        private bool CadastroVeiculoExists(int id)
        {
            return GetCadastroVeiculo(id) != null;
        }

        private async Task<CadastroVeiculoDto> GetCadastroVeiculo(int id)
        {
            return await _getByIdHandler.Handle(GetCadastroVeiculoByIdQuery.NewGetCadastroVeiculoByIdQuery(id));
        }

        #endregion
    }
}
