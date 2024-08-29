using HarfBuzzSharp;
using Microsoft.EntityFrameworkCore.Storage.Json;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Servicios;
using OpticaSurinV2.Clases;
using OpticaSurinV2.Migrations;
using OpticaSurinV2.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpricaSurinV2
{
    public class Gestor
    {
        // Manejo de BD
        public ClienteService clienteService;
        public RecetaService recetaService;
        public PedidoService pedidoService;
        public CobroService cobroService;

        // Atributos 
        public Cliente clienteActual;
        public Receta recetaDelPedido;
        public Cobro cobroDelPedido;
        public Factura facturaDelCobro;
        public float totalPedido;
        public float senaPedido;
        public DateTime fechaRecibido;
        public DateTime fechaPrometido;
        public string observacionesPago;

        // Para pedidos
        public Pedido pedidoSeleccionado;
        public int mesSeleccionado;
        public int anioSeleccionado;

        // Banderas:
        public bool banderaNuevoCliente = false;
        public bool banderanuevaReceta = false;
        public bool banderaClienteEditado = false;

        // Para selector de periodo
        public DateTime fechaDesdePeriodo;
        public DateTime fechaHastaPeriodo;

        // Para aviso de facturacion
        public float totalFacturado;

        // Para anteojo de sol y reparacion
        public string detalleSol;
        public string detalleReparacion;

        // Para obra sociales cmb box
        public List<string> obraSocialesLista = new List<string> { "PARTICULAR", "AVALIAN", "APROSS", "JERARQUICOS", "SANCOR", "OSDE", "FEDERADA", "GENMED", "IMPS", "CAMPAGNUCCI", "MMRC", "OSDOP", "OSFATUN", "OSUTHGRA", "GRASSI", "MUTUAL MEDICA", "PAMI", "OSPECON", "ASISTCARD", "SALUD PLUS", "SALUD 2000", "SADOP", "CAMIONEROS" };

        // Para Informe
        public List<Pedido> pedidosParaInforme;

        // Constructor
        public Gestor(ClienteService clienteServiceOK, RecetaService recetaServiceOK, PedidoService pedidoServiceOK, CobroService cobroServiceOK)
        {
            clienteService = clienteServiceOK;
            recetaService = recetaServiceOK;
            pedidoService = pedidoServiceOK;
            cobroService = cobroServiceOK;
        }

        // Metodos

        #region Validaciones


        // Metodo que valida que la fecha prometido sea mayor o igual a la fecha recibido:
        public bool ValidarFechas(DateTime fechaPrometido)
        {
            /*
            // Obtenemos la fecha actual con solo día, mes y año
            DateTime fechaActual = DateTime.Now.Date;

            // Obtenemos la fecha prometida con solo día, mes y año
            DateTime fechaPrometidoSinHora = fechaPrometido.Date;

            // Comparamos las fechas
            if (fechaActual <= fechaPrometidoSinHora)
                return true;
            else
                return false;
            */
            return true;
        }


        #endregion

        // Getters y setters:

        #region GettersYSetters

        public Cliente GetCliente()
        {
            return clienteActual;
        }
        public void SetClienteActualYaRegistrado(int IdCliente)
        {
            this.clienteActual = clienteService.GetCliente(IdCliente);

        }

        public Receta GetReceta()
        {
            return recetaDelPedido;
        }

        public float GetTotal()
        {
            return totalPedido;
        }

        public float GetSena()
        {
            return senaPedido;
        }

        public DateTime GetFechaRecibido()
        {
            return fechaRecibido;
        }

        public DateTime GetFechaPrometido()
        {
            return fechaPrometido;
        }

        public Cobro GetCobro()
        {
            return this.cobroDelPedido;
        }

        public void SetPedidoSeleccionado(int IdPedidoSelec)
        {
            this.pedidoSeleccionado = pedidoService.GetPedido(IdPedidoSelec);
        }
        public void SetTipoDeReceta(string tipoReceta)
        {
            this.recetaDelPedido.tipo = tipoReceta;
        }

        public string GetObservacionesPago()
        {
            return observacionesPago;
        }

        #endregion

        // Metodos para el calculo de estadisticas e informes:

        #region Estadisticas

        public int[] GetDatosEstadisticosPanelGeneral(List<Pedido> pedidos)
        {
            int totalDinero = 0;
            int saldoPendiente = 0;
            int efectivoTotal = 0;
            int tarjetaTotal = 0;
            int transferenciaTotal = 0;
            
            foreach (Pedido item in pedidos)
            {
                totalDinero += (int)item.total;
                saldoPendiente += (int)item.saldo;

                foreach(Cobro cobro in item.cobros)
                {
                    efectivoTotal += (int)cobro.dineroEfectivo;
                    tarjetaTotal += (int)cobro.dineroTarjeta1;
                    tarjetaTotal += (int)cobro.dineroTarjeta2;
                    transferenciaTotal += (int)cobro.dineroTransferencia;
                }

            }

            int[] array = [totalDinero,
                saldoPendiente,
                efectivoTotal,
                tarjetaTotal,
                transferenciaTotal];

            return array;
        }
        public int[] CalcularDatosTarjetas(List<Pedido> pedidos)
        {
            ;
            // Tengo que recorrer todos los pedidos y cobros de cada pedido, y ir acumulando los totales de cada tipo y marca de tarjeta
            float acumuladorDebito = 0;
            float acumuladorCredito = 0;
            float acumuladorCreditoVisa = 0;
            float acumuladorCreditoMastercard = 0;
            float acumuladorCreditoCabal = 0;
            float acumuladorCreditoNaranja = 0;
            float acumuladorDebitoVisa = 0;
            float acumuladorDebitoMastercard = 0;
            float acumuladorDebitoCabal = 0;


            foreach (Pedido ped in pedidos)
            {
                foreach (Cobro cob in ped.cobros)
                {
                    // Tarjeta 1
                    if (cob.dineroTarjeta1 != 0)
                    {
                        if (cob.tipoTarjeta1 == "Credito")
                        {
                            acumuladorCredito += cob.dineroTarjeta1;
                            // Marcas
                            if (cob.marcaTarjeta1 == "Visa")
                            {
                                acumuladorCreditoVisa += cob.dineroTarjeta1;
                            }
                            else if (cob.marcaTarjeta1 == "Mastercard")
                            {
                                acumuladorCreditoMastercard += cob.dineroTarjeta1;
                            }
                            else if (cob.marcaTarjeta1 == "Cabal")
                            {
                                acumuladorCreditoCabal += cob.dineroTarjeta1;
                            }
                            else if (cob.marcaTarjeta1 == "Naranja")
                            {
                                acumuladorCreditoNaranja += cob.dineroTarjeta1;
                            }
                        }
                        else if (cob.tipoTarjeta1 == "Debito")
                        {
                            acumuladorDebito += cob.dineroTarjeta1;
                            // Marcas
                            if (cob.marcaTarjeta1 == "Visa")
                            {
                                acumuladorDebitoVisa += cob.dineroTarjeta1;
                            }
                            else if (cob.marcaTarjeta1 == "Mastercard")
                            {
                                acumuladorDebitoMastercard += cob.dineroTarjeta1;
                            }
                            else if (cob.marcaTarjeta1 == "Cabal")
                            {
                                acumuladorDebitoCabal += cob.dineroTarjeta1;
                            }
                        }
                    }

                    // Tarjeta 2
                    if (cob.dineroTarjeta2 != 0)
                    {
                        if (cob.tipoTarjeta2 == "Credito")
                        {
                            acumuladorCredito += cob.dineroTarjeta2;
                            // Marcas
                            if (cob.marcaTarjeta2 == "Visa")
                            {
                                acumuladorCreditoVisa += cob.dineroTarjeta2;
                            }
                            else if (cob.marcaTarjeta2 == "Mastercard")
                            {
                                acumuladorCreditoMastercard += cob.dineroTarjeta2;
                            }
                            else if (cob.marcaTarjeta2 == "Cabal")
                            {
                                acumuladorCreditoCabal += cob.dineroTarjeta2;
                            }
                            else if (cob.marcaTarjeta2 == "Naranja")
                            {
                                acumuladorCreditoNaranja += cob.dineroTarjeta2;
                            }
                        }
                        else if (cob.tipoTarjeta2 == "Debito")
                        {
                            acumuladorDebito += cob.dineroTarjeta2;
                            // Marcas
                            if (cob.marcaTarjeta2 == "Visa")
                            {
                                acumuladorDebitoVisa += cob.dineroTarjeta2;
                            }
                            else if (cob.marcaTarjeta2 == "Mastercard")
                            {
                                acumuladorDebitoMastercard += cob.dineroTarjeta2;
                            }
                            else if (cob.marcaTarjeta2 == "Cabal")
                            {
                                acumuladorDebitoCabal += cob.dineroTarjeta2;
                            }
                        }

                    }
                }
            }

            int[] array = new int[] { (int)acumuladorCredito, (int)acumuladorDebito,
                (int)acumuladorCreditoVisa, (int)acumuladorCreditoMastercard, (int)acumuladorCreditoCabal, (int)acumuladorCreditoNaranja,
                (int)acumuladorDebitoVisa, (int)acumuladorDebitoMastercard, (int)acumuladorDebitoCabal};

            return array;
        }

        public List<System.Object> CalcularDatosObrasSociales(List<Pedido> pedidos)
        {
            // Tengo que recorrer todos los pedidos y cobros de cada pedido, y ir acumulando los totales de cada obra social
            int[] arrayAcumuladores = new int[obraSocialesLista.Count];
            string[] arrayObraSociales = obraSocialesLista.ToArray();

            int totalObrasSociales = 0;
            foreach (Pedido ped in pedidos)
            {
                foreach (Cobro cob in ped.cobros)
                {
                    int posicion = Array.IndexOf(arrayObraSociales, cob.nombreObraSocial);
                    if (posicion >= 0)
                    {
                        arrayAcumuladores[posicion] += (int)cob.dineroObraSocial;
                        if (cob.nombreObraSocial != "PARTICULAR")
                        {
                            totalObrasSociales += (int)cob.dineroObraSocial;
                        }
                    }
                }
            }
            // Combinar los arrays en una lista de tuplas
            var combinedList = arrayObraSociales.Zip(arrayAcumuladores, (obraSocial, acumulador) => new { ObraSocial = obraSocial, Acumulador = acumulador }).ToList();

            // Ordenar la lista de tuplas por el valor del acumulador de mayor a menor
            combinedList = combinedList.OrderByDescending(item => item.Acumulador).ToList();

            // Separar los valores ordenados en dos arrays
            for (int i = 0; i < combinedList.Count; i++)
            {
                arrayObraSociales[i] = combinedList[i].ObraSocial;
                arrayAcumuladores[i] = combinedList[i].Acumulador;
            }

            return new List<System.Object> { arrayObraSociales, arrayAcumuladores , totalObrasSociales};
        }

        public int[] CalcularDatosInfoGeneral(List<Pedido> pedidos)
        {
            // Tengo que recorrer todos los pedidos y cobros de cada pedido, y ir acumulando los totales de cada obra social
            int cantidadTotalDePedidos = pedidos.Count;
            float acumuladorFacturado = 0;
            float acumuladorReceta = 0;
            float acumuladorSol = 0;
            float acumuladorArreglo = 0;

            foreach (Pedido ped in pedidos)
            {
                foreach (Cobro cob in ped.cobros)
                {
                    if (cob.factura.totalItems.Count > 0)
                    {
                        foreach (float monto in cob.factura.totalItems)
                        {
                            acumuladorFacturado += monto;
                        }
                    }
                }

                if (ped.tipo == "RECETA")
                {
                    acumuladorReceta += ped.total;
                }
                else if (ped.tipo == "SOL")
                {
                    acumuladorSol += ped.total;
                }
                else if (ped.tipo == "REPARACION")
                {
                    acumuladorArreglo += ped.total;
                }
            }

            int[] array = new int[] {cantidadTotalDePedidos, (int)acumuladorFacturado, (int)acumuladorReceta, 
            (int)acumuladorSol, (int)acumuladorArreglo};

            return array;
        }

        public List<System.Object> CalcularDatosInformeAnual(List<Pedido> pedidos)
        {
            int cantidadTotalDePedidos = pedidos.Count;

            float totalDinero = 0;
            float efectivoTotal = 0;
            float tarjetaTotal = 0;
            float transferenciaTotal = 0;
            float acumuladorFacturado = 0;
            float acumuladorReceta = 0;
            float acumuladorSol = 0;
            float acumuladorArreglo = 0;
            int[] acumuladoresPorMes = new int[12];

            foreach (Pedido item in pedidos)
            {
                totalDinero += item.total;

                foreach (Cobro cobro in item.cobros)
                {
                    efectivoTotal += cobro.dineroEfectivo;
                    tarjetaTotal += cobro.dineroTarjeta1;
                    tarjetaTotal += cobro.dineroTarjeta2;
                    transferenciaTotal += cobro.dineroTransferencia;

                    if (cobro.factura.totalItems.Count > 0)
                    {
                        foreach (float monto in cobro.factura.totalItems)
                        {
                            acumuladorFacturado += monto;
                        }
                    }
                }

                if (item.tipo == "RECETA")
                {
                    acumuladorReceta += item.total;
                }
                else if (item.tipo == "SOL")
                {
                    acumuladorSol += item.total;
                }
                else if (item.tipo == "REPARACION")
                {
                    acumuladorArreglo += item.total;
                }

                int mesPedido = item.fechaRecibido.Month;
                acumuladoresPorMes[mesPedido - 1] += (int)item.total;
            }

            float ingresoPromedio = totalDinero / 12;

            /*       1              2               3               4               5
             * cant pedidos ,  total dinero, efectivo total, tarjeta total, transferencia total,
             *         6              7           8             9                 10
                total facturado, total receta, total sol, total arreglo, acumuladores por mes,
                        11
                ingreso promedio    */

            return new List<System.Object> { cantidadTotalDePedidos, (int)totalDinero, (int)efectivoTotal, (int)tarjetaTotal, (int)transferenciaTotal,
            (int)acumuladorFacturado, (int)acumuladorReceta, (int)acumuladorSol, (int)acumuladorArreglo, acumuladoresPorMes, (int)ingresoPromedio};
        }
        #endregion

    }
}
