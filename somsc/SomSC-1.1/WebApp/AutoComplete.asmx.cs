/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Data;
using System.Web.Services;
using AjaxControlToolkit;
using Com.Gt.SomSc.Domain.Entities;

namespace Com.Gt.SomSc.WebApp
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetProdutos(string prefixText)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                return context.Produtos.Where(p => p.Descricao.Contains(prefixText)).Select(p => p.Codigo + " - " + p.Descricao).ToList();
            }
        }

        [WebMethod]
        public List<CascadingDropDownNameValue> GetCategorias(string knownCategoryValues, string category)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                List<CascadingDropDownNameValue> values = context.Categorias.Select(c => new CascadingDropDownNameValue(c.Descricao, c.Id.ToString())).ToList();

                return values;
            }
        }

        [WebMethod]
        public List<CascadingDropDownNameValue> GetProdutosForCategoria(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int categoriaId;
            if (!kv.ContainsKey("Categoria") || !Int32.TryParse(kv["Categoria"], out categoriaId))
                return null;

            using (SomScDataContext context = new SomScDataContext())
            {
                List<CascadingDropDownNameValue> values = context.Produtos.Where(p => p.IdCategoria == categoriaId).Select(p => new CascadingDropDownNameValue(p.Descricao, p.Id.ToString())).ToList();

                return values;
            }
        }
    }
}
