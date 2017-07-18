using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Application.Main.Interfaces;
using System.Net;

namespace Web.Controllers
{
    public class PermissionController : Controller
    {
        //Declaración de variables globales
        private readonly IPermissionAppService app; //Corresponde a una instancia de la interfaz de permisos en la capa de aplicación

        /**
         * <summary>Método constructor</summary>
         * <param name="app">Corresponde a la interfaz de permisos de la capa de aplicación</param>
         */
        public PermissionController(IPermissionAppService app)
        {
            this.app = app;
        }//Fin del método

        // GET: Permission
        public ActionResult Index()
        {
            return View(this.app.getAll()); //Le pasamos la lista de permisos que existe en la base de datos
        }//Fin del método

        // GET: Permission/Details/5
        public ActionResult Details(int id)
        {
            tbpermission tbpermission = this.app.getById(id); //Le obtenemos la información de un permiso
            if (tbpermission == null)
            {
                return HttpNotFound();
            }
            return View(tbpermission);
        }//Fin del método

        // GET: Permission/Create
        public ActionResult Create()
        {
            return View();
        }//Fin del método

        // POST: Permission/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbpermission permission)
        {
            if (ModelState.IsValid)
            {
                //Se valida que el nombre no exista en la base de datos
                if (this.nameUnique(permission.nametbpermission, 0))
                {
                    this.app.add(permission);

                    return RedirectToAction("Index");
                }
            }//Fin del if
            return View(permission);
        }//Fin del método

        // GET: Permission/Edit/5
        public ActionResult Edit(int id)
        {
            tbpermission tbpermission = this.app.getById(id);
            if (tbpermission == null)
            {
                return HttpNotFound();
            }
            return View(tbpermission);
        }//Fin del método

        // POST: Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(tbpermission permission)
        {
            if (ModelState.IsValid)
            {
                //Se valida que el nombre sea único en la base de datos
                if (this.nameUnique(permission.nametbpermission, permission.identifytbpermission))
                {
                    this.app.modify(permission);
                    return RedirectToAction("Index");
                }
            }//Fin del if

            return View(permission);
        }//Fin del método

        // GET: Permission/Delete/5
        public ActionResult Delete(int id)
        {
            tbpermission tbpermission = this.app.getById(id);
            if (tbpermission == null)
            {
                return HttpNotFound();
            }
            return View(tbpermission);
        }//Fin del método

        // POST: Permission/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            this.app.delete(id);
            return RedirectToAction("Index");
        }//Fin del método

        /**
         * <summary>Método que valida que el nombre sea único en la base de datos.</summary>
         * <param name="id">Corresponde al identificador del permiso, si es un nuevo registro se pasa como valor un cero.</param>
         * <param name="name">Corresponde al nombre del permiso</param>
         */
        private Boolean nameUnique(string name, int id)
        {
            var permission = this.app.getAll();

            //Se recorre todos los permisos
            foreach (var current in permission)
            {
                if (current.nametbpermission == name)
                {
                    //Si son iguales lo que está es actualizando, en caso contrario es un nuevo registro
                    return (current.identifytbpermission == id);
                }//Fin del if
            }//Fin del foreach
            return true;
        }//fin del método nameUnique
    }//Fin de la clase
}//Fin del namespace
