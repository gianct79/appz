/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Services;
using AjaxControlToolkit;
using Com.Gt.SomSc.Common.Log;
using Com.Gt.SomSc.Domain.Entities;

namespace Com.Gt.SomSc.DynApp
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] GetProdutos(string prefixText)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                return context.Produtos.Where(p => p.Descricao.Contains(prefixText)).Select(p => p.Codigo + " - " + p.Descricao).ToArray();
            }
        }

        [WebMethod]
        public string[] GetProdutosByCodigo(string prefixText)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                return context.Produtos.Where(p => p.Codigo.Contains(prefixText)).Select(p => p.Codigo + " - " + p.Descricao).ToArray();
            }
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetCategorias(string knownCategoryValues, string category)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                return context.Categorias.Select(c => new CascadingDropDownNameValue(c.Descricao, c.Id.ToString())).ToArray();
            }
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetProdutosForCategoria(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int categoriaId;
            if (!kv.ContainsKey("Categoria") || !Int32.TryParse(kv["Categoria"], out categoriaId))
                return null;

            using (SomScDataContext context = new SomScDataContext())
            {
                return context.Produtos.Where(p => p.IdCategoria == categoriaId).Select(p => new CascadingDropDownNameValue(p.Descricao, p.Id.ToString())).ToArray();
            }
        }
    }


}
