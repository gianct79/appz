/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Linq;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Domain.Entities;
using System.Collections.Generic;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class CriticoGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CriticosListView_Load(object sender, EventArgs e)
        {
            ApplyFilter(null);
        }

        protected void CriticosListView_Sorting(object sender, ListViewSortEventArgs e)
        {
            ApplyFilter(e);
        }

        private void ApplyFilter(ListViewSortEventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                int idCategoria = 0;
                if (!string.IsNullOrEmpty(CategoriaFilterComboBox.DataBindID))
                {
                    idCategoria = Convert.ToInt32(CategoriaFilterComboBox.DataBindID);
                }

                int idFornecedor = 0;
                if (!string.IsNullOrEmpty(FornecedorFilterComboBox.DataBindID))
                {
                    idFornecedor = Convert.ToInt32(FornecedorFilterComboBox.DataBindID);
                }

                IEnumerable<Com.Gt.SomSc.Domain.Entities.Saldo> saldos = context.GetCriticos(idCategoria, idFornecedor);

                if (e != null)
                {
                    switch (e.SortExpression)
                    {
                        case "Produto.Codigo":
                            {
                                if (e.SortDirection == SortDirection.Ascending)
                                    saldos = saldos.OrderBy(s => s.Produto.Codigo);
                                else
                                    saldos = saldos.OrderByDescending(s => s.Produto.Codigo);
                            }
                            break;

                        case "Produto.Descricao":
                            {
                                if (e.SortDirection == SortDirection.Ascending)
                                    saldos = saldos.OrderBy(s => s.Produto.Descricao);
                                else
                                    saldos = saldos.OrderByDescending(s => s.Produto.Descricao);
                            }
                            break;

                        case "Produto.Critico":
                            {
                                if (e.SortDirection == SortDirection.Ascending)
                                    saldos = saldos.OrderBy(s => s.Produto.Critico);
                                else
                                    saldos = saldos.OrderByDescending(s => s.Produto.Critico);
                            }
                            break;

                        case "Saldo":
                            {
                                if (e.SortDirection == SortDirection.Ascending)
                                    saldos = saldos.OrderBy(s => s.Qtde);
                                else
                                    saldos = saldos.OrderByDescending(s => s.Qtde);
                            }
                            break;

                        default:
                            break;
                    }
                }

                CriticosListView.DataSource = saldos;
                CriticosListView.DataBind();
            }
        }
    }
}