﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Suppliers
{
    [Route("Api/Farm")]
    [ApiController]
    public class FarmController : Controller
    {
        IFarmDSL _farmDSL;
        public FarmController(IFarmDSL farmDSL)
        {
            this._farmDSL = farmDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _farmDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _farmDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(FarmDTO model) => Ok(await _farmDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _farmDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _farmDSL.GetAllLite());
    }
}