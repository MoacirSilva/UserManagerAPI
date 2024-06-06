using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagerAPI.Domain.Data;
using UserManagerAPI.Domain.Entities;

namespace UserManagerAPI.Controllers
{
    public class GrupoUsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public GrupoUsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GrupoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.grupoUsuarios.ToListAsync());
        }

        // GET: GrupoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.grupoUsuarios
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,Descricao,Administrador,DataCadastro,DataAlteracao")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.grupoUsuarios.FindAsync(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }
            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,Descricao,Administrador,DataCadastro,DataAlteracao")] GrupoUsuario grupoUsuario)
        {
            if (id != grupoUsuario.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoUsuarioExists(grupoUsuario.IdGrupo))
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
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.grupoUsuarios
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoUsuario = await _context.grupoUsuarios.FindAsync(id);
            if (grupoUsuario != null)
            {
                _context.grupoUsuarios.Remove(grupoUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoUsuarioExists(int id)
        {
            return _context.grupoUsuarios.Any(e => e.IdGrupo == id);
        }
    }
}
