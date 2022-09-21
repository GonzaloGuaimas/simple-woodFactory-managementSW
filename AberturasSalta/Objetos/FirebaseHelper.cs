using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AberturasSalta.Objetos;
namespace AberturasSalta.Objetos
{
    public class FirebaseHelper
    {

        FirebaseClient firebase = new FirebaseClient("https://aberturassalta-51297-default-rtdb.firebaseio.com/");














        //_________________________________________________________________________________________________________
        //---------------------------------USUARIO-----------------------------------------------------------------
        public async Task addUsuario(Usuario usuario)
        {
            var toUpdateUsuario = (await firebase.Child("Usuarios").OnceAsync<Usuario>()).Where(a => a.Object.nombre == usuario.nombre).FirstOrDefault();
            if (toUpdateUsuario != null)
                await firebase.Child("Usuarios").Child(toUpdateUsuario.Key).PutAsync(toUpdateUsuario.Object);
            else
            {
                await firebase.Child("Usuarios").PostAsync(usuario);
                toUpdateUsuario = (await firebase.Child("Usuarios").OnceAsync<Usuario>()).Where(a => a.Object.nombre == usuario.nombre).FirstOrDefault();
                if (toUpdateUsuario != null)
                {
                    Usuario user = usuario;
                    user.key = toUpdateUsuario.Key;
                    await firebase.Child("Usuarios").Child(toUpdateUsuario.Key).PutAsync(user);
                }
            }
        }

        public async Task<List<Usuario>> getAllUsuario()
        {
            return (await firebase.Child("Usuarios").OnceAsync<Usuario>()).Select(item => item.Object).ToList();
        }

        public async Task<Usuario> getUsuario(string dni)
        {
            var allProductos = await getAllUsuario();
            await firebase.Child("Usuarios").OnceAsync<Usuario>();
            return allProductos.Where(a => a.dni == dni).FirstOrDefault();
        }

        public async Task deleteUsuario(string id)
        {
            var toDeleteProducto = (await firebase.Child("Usuarios").OnceAsync<Usuario>()).Where(a => a.Object.dni == id).FirstOrDefault();
            await firebase.Child("Usuarios").Child(toDeleteProducto.Key).DeleteAsync();
        }














        //_________________________________________________________________________________________________________
        //---------------------------------CLIENTE-----------------------------------------------------------------
        public async Task addCliente(Cliente cliente)
        {
            var toUpdateUsuario = (await firebase.Child("Clientes").OnceAsync<Cliente>()).Where(a => a.Object.nombre == cliente.nombre).FirstOrDefault();
            if (toUpdateUsuario != null)
                await firebase.Child("Clientes").Child(toUpdateUsuario.Key).PutAsync(toUpdateUsuario.Object);
            else
            {
                await firebase.Child("Clientes").PostAsync(cliente);
                toUpdateUsuario = (await firebase.Child("Clientes").OnceAsync<Cliente>()).Where(a => a.Object.nombre == cliente.nombre).FirstOrDefault();
                if (toUpdateUsuario != null)
                {
                    Cliente clie = cliente;
                    clie.key = toUpdateUsuario.Key;
                    await firebase.Child("Clientes").Child(toUpdateUsuario.Key).PutAsync(clie);
                }
            }
        }

        public async Task<List<Cliente>> getAllClientes()
        {
            return (await firebase.Child("Clientes").OnceAsync<Cliente>()).Select(item => item.Object).ToList();
        }

        public async Task<Cliente> getCliente(string dni)
        {
            var allProductos = await getAllClientes();
            await firebase.Child("Clientes").OnceAsync<Usuario>();
            return allProductos.Where(a => a.dnicuit == dni).FirstOrDefault();
        }

        public async Task deleteCliente(string id)
        {
            var toDeleteProducto = (await firebase.Child("Clientes").OnceAsync<Cliente>()).Where(a => a.Object.dnicuit == id).FirstOrDefault();
            await firebase.Child("Clientes").Child(toDeleteProducto.Key).DeleteAsync();
        }




















        //_________________________________________________________________________________________________________
        //---------------------------------PRODUCTO-----------------------------------------------------------------
        public async Task addProducto(Producto producto)
        {
            var toUpdate = (await firebase.Child("Productos").OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();
            if (toUpdate != null)
                await firebase.Child("Productos").Child(toUpdate.Key).PutAsync(producto);
            else
            {
                await firebase.Child("Productos").PostAsync(producto);
                toUpdate = (await firebase.Child("Productos").OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();
                if (toUpdate != null)
                {
                    Producto prod = producto;
                    prod.key = toUpdate.Key;
                    await firebase.Child("Productos").Child(toUpdate.Key).PutAsync(prod);
                }
            }
        }
        public async Task stockProducto(List<Producto> productos,int operacion,string atributo)
        {
            foreach (var producto in productos)
            {
                var toUpdate = (await firebase.Child("Productos").OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();
                if (toUpdate != null)
                {
                    switch (atributo)
                    {

                        //-----------------------------------------------AUMENTA GRAL Y DEP----------------------------------------------------------------------
                        case "graldep":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            if (toUpdate.Object.gral != null)
                                toUpdate.Object.gral = (Int32.Parse(toUpdate.Object.gral) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.gral = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;

                        //---------------------------------------------------DISMINMUYE DEP Y AUMENTA SUCUR--------------------------------------------------------------
                        case "depZuviria":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.A != null)
                                toUpdate.Object.A = (Int32.Parse(toUpdate.Object.A) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.A = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "depIndependencia":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.B != null)
                                toUpdate.Object.B = (Int32.Parse(toUpdate.Object.B) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.B = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "depSanta Lucia":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.C != null)
                                toUpdate.Object.C = (Int32.Parse(toUpdate.Object.C) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.C = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "depChile":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.D != null)
                                toUpdate.Object.D = (Int32.Parse(toUpdate.Object.D) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.D = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "depLa Isla":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.E != null)
                                toUpdate.Object.E = (Int32.Parse(toUpdate.Object.E) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.E = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "depF":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.F != null)
                                toUpdate.Object.F = (Int32.Parse(toUpdate.Object.F) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.F = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        //-------------------------------------------DISMINUYE GRAL Y  AUM-------------------------------------------------------------------
                        case "gralZuviria":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.A != null)
                                toUpdate.Object.A = (Int32.Parse(toUpdate.Object.A) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.A = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gralIndependencia":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.B != null)
                                toUpdate.Object.B = (Int32.Parse(toUpdate.Object.B) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.B = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gralSanta Lucia":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.C != null)
                                toUpdate.Object.C = (Int32.Parse(toUpdate.Object.C) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.C = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gralChile":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.D != null)
                                toUpdate.Object.D = (Int32.Parse(toUpdate.Object.D) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.D = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gralLa Isla":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.E != null)
                                toUpdate.Object.E = (Int32.Parse(toUpdate.Object.E) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.E = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gralF":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * -1 * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * -1).ToString();
                            if (toUpdate.Object.F != null)
                                toUpdate.Object.F = (Int32.Parse(toUpdate.Object.F) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.F = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;

                        //------------------------------------------------------------------------------------------------------------------------------

                        case "dep":
                            if (toUpdate.Object.dep != null)
                                toUpdate.Object.dep = (Int32.Parse(toUpdate.Object.dep) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.dep = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "gral":
                            if (toUpdate.Object.gral != null)
                                toUpdate.Object.gral = (Int32.Parse(toUpdate.Object.gral) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.gral = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "Zuviria":
                            if (toUpdate.Object.A != null)
                                toUpdate.Object.A = (Int32.Parse(toUpdate.Object.A) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.A = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "Independencia":
                            if (toUpdate.Object.B != null)
                                toUpdate.Object.B = (Int32.Parse(toUpdate.Object.B) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.B = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "Santa Lucia":
                            if (toUpdate.Object.C != null)
                                toUpdate.Object.C = (Int32.Parse(toUpdate.Object.C) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.C = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "Chile":
                            if (toUpdate.Object.D != null)
                                toUpdate.Object.D = (Int32.Parse(toUpdate.Object.D) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.D = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "La Isla":
                            if (toUpdate.Object.E != null)
                                toUpdate.Object.E = (Int32.Parse(toUpdate.Object.E) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.E = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                        case "F":
                            if (toUpdate.Object.F != null)
                                toUpdate.Object.F = (Int32.Parse(toUpdate.Object.F) + 1 * operacion * Int32.Parse(producto.cantidad)).ToString();
                            else
                                toUpdate.Object.F = (Int32.Parse(producto.cantidad) * operacion).ToString();
                            break;
                    }
                    firebase.Child("Productos").Child(toUpdate.Key).PutAsync(toUpdate.Object);
                }
            }
        }
        public async Task<List<Producto>> getAllProductos()
        {
            return (await firebase.Child("Productos").OnceAsync<Producto>()).Select(item => item.Object).ToList();
        }

        public async Task<Producto> getProducto(string id)
        {
            var allProductos = await getAllProductos();
            await firebase.Child("Productos").OnceAsync<Producto>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteProducto(string id)
        {
            var toDeleteProducto = (await firebase.Child("Productos").OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Productos").Child(toDeleteProducto.Key).DeleteAsync();
        }














        //_________________________________________________________________________________________________________
        //---------------------------------REMITOS-----------------------------------------------------------------
        public async Task addRemito(Remito remito)
        {
            var toUpdate = (await firebase.Child("Remitos").OnceAsync<Remito>()).Where(a => a.Object.id == remito.id).FirstOrDefault();
            if (toUpdate != null)
                firebase.Child("Remitos").Child(toUpdate.Key).PutAsync(remito);
            else
            {
                await firebase.Child("Remitos").PostAsync(remito);
                toUpdate = (await firebase.Child("Remitos").OnceAsync<Remito>()).Where(a => a.Object.id == remito.id).FirstOrDefault();
                if (toUpdate != null)
                {
                    Remito rem = remito;
                    rem.key = toUpdate.Key;
                    firebase.Child("Remitos").Child(toUpdate.Key).PutAsync(rem);
                }
            }
        }

        public async Task<List<Remito>> getAllRemitos()
        {
            return (await firebase.Child("Remitos").OnceAsync<Remito>()).Select(item => item.Object).ToList();
        }

        public async Task<Remito> getRemito(string id)
        {
            var allProductos = await getAllRemitos();
            await firebase.Child("Remitos").OnceAsync<Remito>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteRemito(string id)
        {
            var toDeleteProducto = (await firebase.Child("Remitos").OnceAsync<Remito>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Remitos").Child(toDeleteProducto.Key).DeleteAsync();
        }
















        //_________________________________________________________________________________________________________
        //---------------------------------VENTAS-----------------------------------------------------------------
        public async Task addVenta(Venta venta)
        {
            var toUpdate = (await firebase.Child("Ventas").OnceAsync<Venta>()).Where(a => a.Object.id == venta.id).FirstOrDefault();
            if (toUpdate != null)
                firebase.Child("Ventas").Child(toUpdate.Key).PutAsync(venta);
            else
            {
                await firebase.Child("Ventas").PostAsync(venta);
                toUpdate = (await firebase.Child("Ventas").OnceAsync<Venta>()).Where(a => a.Object.id == venta.id).FirstOrDefault();
                if (toUpdate != null)
                {
                    Venta ven = venta;
                    ven.key = toUpdate.Key;
                    firebase.Child("Ventas").Child(toUpdate.Key).PutAsync(ven);
                }
            }
        }

        public async Task<List<Venta>> getAllVentas()
        {
            return (await firebase.Child("Ventas").OnceAsync<Venta>()).Select(item => item.Object).ToList();
        }

        public async Task<Venta> getVenta(string id)
        {
            var allProductos = await getAllVentas();
            await firebase.Child("Ventas").OnceAsync<Venta>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteVenta(string id)
        {
            var toDeleteProducto = (await firebase.Child("Ventas").OnceAsync<Venta>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Ventas").Child(toDeleteProducto.Key).DeleteAsync();
        }
















        //_________________________________________________________________________________________________________
        //---------------------------------FORMA PAGO-----------------------------------------------------------------
        public async Task addFormaPago(FormaPago forma)
        {
            var toUpdateUsuario = (await firebase.Child("FormasPagos").OnceAsync<FormaPago>()).Where(a => a.Object.id == forma.id).FirstOrDefault();
            if (toUpdateUsuario != null)
                await firebase.Child("FormasPagos").Child(toUpdateUsuario.Key).PutAsync(toUpdateUsuario.Object);
            else
            {
                await firebase.Child("FormasPagos").PostAsync(forma);
                toUpdateUsuario = (await firebase.Child("FormasPagos").OnceAsync<FormaPago>()).Where(a => a.Object.id == forma.id).FirstOrDefault();
                if (toUpdateUsuario != null)
                {
                    FormaPago form = forma;
                    form.key = toUpdateUsuario.Key;
                    await firebase.Child("FormasPagos").Child(toUpdateUsuario.Key).PutAsync(form);
                }
            }
        }

        public async Task<List<FormaPago>> getAllFormaPago()
        {
            return (await firebase.Child("FormasPagos").OnceAsync<FormaPago>()).Select(item => item.Object).ToList();
        }

        public async Task<FormaPago> getFormaPago(string id)
        {
            var allProductos = await getAllFormaPago();
            await firebase.Child("FormasPagos").OnceAsync<FormaPago>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteFormaPago(string id)
        {
            var toDeleteProducto = (await firebase.Child("FormasPagos").OnceAsync<FormaPago>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("FormasPagos").Child(toDeleteProducto.Key).DeleteAsync();
        }

























        //_________________________________________________________________________________________________________
        //---------------------------------ARQUEO-----------------------------------------------------------------
        public async Task addArqueo(ArqueoCaja arqueo)
        {
            var toUpdateUsuario = (await firebase.Child("Arqueos").OnceAsync<ArqueoCaja>()).Where(a => a.Object.id == arqueo.id).FirstOrDefault();
            if (toUpdateUsuario != null)
                await firebase.Child("Arqueos").Child(toUpdateUsuario.Key).PutAsync(toUpdateUsuario.Object);
            else
            {
                await firebase.Child("Arqueos").PostAsync(arqueo);
                toUpdateUsuario = (await firebase.Child("Arqueos").OnceAsync<ArqueoCaja>()).Where(a => a.Object.id == arqueo.id).FirstOrDefault();
                if (toUpdateUsuario != null)
                {
                    ArqueoCaja form = arqueo;
                    form.key = toUpdateUsuario.Key;
                    await firebase.Child("Arqueos").Child(toUpdateUsuario.Key).PutAsync(form);
                }
            }
        }

        public async Task<List<ArqueoCaja>> getAllArqueo()
        {
            return (await firebase.Child("Arqueos").OnceAsync<ArqueoCaja>()).Select(item => item.Object).ToList();
        }

        public async Task<ArqueoCaja> getArqueo(string id)
        {
            var allProductos = await getAllArqueo();
            await firebase.Child("Arqueos").OnceAsync<ArqueoCaja>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteArqueo(string id)
        {
            var toDeleteProducto = (await firebase.Child("Arqueos").OnceAsync<ArqueoCaja>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Arqueos").Child(toDeleteProducto.Key).DeleteAsync();
        }



















        //_________________________________________________________________________________________________________
        //---------------------------------CONTRASÑEA-----------------------------------------------------------------
        public async Task addContraseña(Contraseña contraseña)
        {
            var toUpdateUsuario = (await firebase.Child("Contraseñas").OnceAsync<Contraseña>()).Where(a => a.Object.id == contraseña.id).FirstOrDefault();
            if (toUpdateUsuario != null)
                await firebase.Child("Contraseñas").Child(toUpdateUsuario.Key).PutAsync(toUpdateUsuario.Object);
            else
            {
                await firebase.Child("Contraseñas").PostAsync(contraseña);
                toUpdateUsuario = (await firebase.Child("Contraseñas").OnceAsync<Contraseña>()).Where(a => a.Object.id == contraseña.id).FirstOrDefault();
                if (toUpdateUsuario != null)
                {
                    Contraseña user = contraseña;
                    user.key = toUpdateUsuario.Key;
                    await firebase.Child("Contraseñas").Child(toUpdateUsuario.Key).PutAsync(user);
                }
            }
        }

        public async Task<List<Contraseña>> getAllContraseña()
        {
            return (await firebase.Child("Contraseñas").OnceAsync<Contraseña>()).Select(item => item.Object).ToList();
        }

        public async Task<Contraseña> getContraseña(string id)
        {
            var allProductos = await getAllContraseña();
            await firebase.Child("Contraseñas").OnceAsync<Contraseña>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task deleteContraseña(string id)
        {
            var toDeleteProducto = (await firebase.Child("Contraseñas").OnceAsync<Contraseña>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Contraseñas").Child(toDeleteProducto.Key).DeleteAsync();
        }
        public async Task deleteContraseña24HS(List<Contraseña> contraseñas)
        {
            foreach (var contraseña in contraseñas)
            {
                if (!contraseña.fecha.Equals(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    var toDeleteProducto = (await firebase.Child("Contraseñas").OnceAsync<Contraseña>()).Where(a => a.Object.id == contraseña.id).FirstOrDefault();
                    await firebase.Child("Contraseñas").Child(toDeleteProducto.Key).DeleteAsync();
                }
            }
        }






















        //_________________________________________________________________________________________________________
        //---------------------------------DETALLEVENTAS-----------------------------------------------------------------

        public async Task<List<Producto>> getAllDetalleVenta()
        {
            return (await firebase.Child("Detalles").Child("DetalleVenta").OnceAsync<Producto>()).Select(item => item.Object).ToList();
        }
        public async Task addDetalleVenta(List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase.Child("Detalles").Child("DetalleVenta").PostAsync(producto);
            }
        }
        public async Task deleteDetalleVenta(string id)
        {
            var toDeleteProducto = (await firebase.Child("Detalles").Child("DetalleVenta").OnceAsync<Producto>()).Where(a => a.Object.foranea == id).FirstOrDefault();
            await firebase.Child("Detalles").Child("DetalleVenta").Child(toDeleteProducto.Key).DeleteAsync();
        }















        //_________________________________________________________________________________________________________
        //---------------------------------DETALLEREMITOS-----------------------------------------------------------------

        public async Task<List<Producto>> getAllDetalleRemitos()
        {
            return (await firebase.Child("Detalles").Child("DetalleRemito").OnceAsync<Producto>()).Select(item => item.Object).ToList();
        }
        public async Task addDetalleRemito(List<Producto> productos)
        {
            foreach (var producto in productos)
                await firebase.Child("Detalles").Child("DetalleRemito").PostAsync(producto);
        }
        public async Task deleteDetalleRemito(string id)
        {
            var detalleRemitos = await getAllDetalleRemitos();
            foreach (var producto in detalleRemitos)
                if (producto.foranea.Equals(id))
                    await firebase.Child("Detalles").Child("DetalleRemito").Child(producto.key).DeleteAsync();
        }















        //_________________________________________________________________________________________________________
        //---------------------------------DETALLEPAGO-----------------------------------------------------------------

        public async Task<List<Pago>> getAllDetallePagos()
        {
            return (await firebase.Child("Detalles").Child("DetallePago").OnceAsync<Pago>()).Select(item => item.Object).ToList();
        }
        public async Task addDetallePago(List<Pago> pagos)
        {
            foreach (var pago in pagos)
                await firebase.Child("Detalles").Child("DetallePago").PostAsync(pago);
        }
        public async Task deleteDetallePago(string id)
        {
            var toDeleteProducto = (await firebase.Child("Detalles").Child("DetallePago").OnceAsync<Pago>()).Where(a => a.Object.foranea == id).FirstOrDefault();
            if (toDeleteProducto!=null)
            {
                await firebase.Child("Detalles").Child("DetallePago").Child(toDeleteProducto.Key).DeleteAsync();
            }
            
        }

    }
}
