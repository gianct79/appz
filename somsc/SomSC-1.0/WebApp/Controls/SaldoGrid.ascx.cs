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
    public partial class SaldoGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SaldosListView_Sorting(object sender, ListViewSortEventArgs e)
        {
            ApplyFilter(e);
        }

        protected void SaldosListView_Load(object sender, EventArgs e)
        {
            ApplyFilter(null);
        }

        private void ApplyFilter(ListViewSortEventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                IEnumerable<Com.Gt.SomSc.Domain.Entities.Saldo> saldos = context.GetSaldos();

                if (!string.IsNullOrEmpty(ProdutoFilterComboBox.DataBindID) && !string.IsNullOrEmpty(FilialFilterComboBox.DataBindID))
                {
                    saldos = saldos.Where(s => s.Produto.Id == Convert.ToInt32(ProdutoFilterComboBox.DataBindID) && s.Filial.Id == Convert.ToInt32(FilialFilterComboBox.DataBindID));
                }
                else if (!string.IsNullOrEmpty(ProdutoFilterComboBox.DataBindID))
                {
                    saldos = saldos.Where(s => s.Produto.Id == Convert.ToInt32(ProdutoFilterComboBox.DataBindID));
                }
                else if (!string.IsNullOrEmpty(FilialFilterComboBox.DataBindID))
                {
                    saldos = saldos.Where(s => s.Filial.Id == Convert.ToInt32(FilialFilterComboBox.DataBindID));
                }

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

                        case "Filial.Nome":
                            {
                                if (e.SortDirection == SortDirection.Ascending)
                                    saldos = saldos.OrderBy(s => s.Filial.Nome);
                                else
                                    saldos = saldos.OrderByDescending(s => s.Filial.Nome);
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

                SaldosListView.DataSource = saldos;
                SaldosListView.DataBind();
            }
        }
    }
}