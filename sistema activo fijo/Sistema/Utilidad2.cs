using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Sistema
{
    class Utilidad2
    {
        string nombresDB;

        public Utilidad2(string value)
        {
            nombresDB = value;
        }

        public void createDB()
        {
            string str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            str = "CREATE DATABASE " + nombresDB;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        public void crearTables()
        {

            SqlConnection myConn = new SqlConnection("data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;");

            string str = "create table usuario(id integer not null primary key,nombres varchar(50) not null,direccion varchar(30)not null,sexo char(1) not null)";

            string grupo = "CREATE TABLE GRUPOS (CODGRUPO int not null identity(1,1), DESCRIPCION varchar(30) NOT NULL, primary key (CODGRUPO))";

            string persona = "CREATE TABLE Persona ( personaID integer  primary key,nombres varchar(30) NOT NULL,apellidos varchar(30) NOT NULL,direccion varchar(30) NOT NULL,sexo char(1) NOT NULL,tipo varchar(20) NOT NULL);";

            //string contacto = "CREATE TABLE Contacto (contactoID Integer primary key,personaID Integer NOT NULL,tipo_contacto varchar(20) NOT NULL,referencia varchar(20) NOT NULL,foreign key(personaID)references Persona(personaID));";

            //string cliente = "CREATE TABLE Cliente (clienteID Integer primary key,tipo varchar(20) NOT NULL);";

            //string forCliente = "alter table Cliente ADD CONSTRAINT FK_Cliente_Persona foreign key(clienteID)references Persona(personaID)on update cascade on delete cascade;";

            string empleado = "CREATE TABLE Empleado (empleadoID Integer primary key ,grupoID Integer NOT NULL,cargo varchar(20) NOT NULL,estado varchar(20) NOT NULL,disponibildad varchar(20) NOT NULL,nick varchar(20) NOT NULL,password varchar(200) NOT NULL,foreign key(grupoID)references GRUPOS(CODGRUPO));";

            string forEmpleado = "alter table Empleado add foreign key(empleadoID) references Persona(personaID)on update no action on delete no action";

            string sesion = "create table InicioSesion(sesionID integer primary key,inicio datetime not null,fin datetime not null,empleadoID integer not null,foreign key(empleadoID)references Empleado(empleadoID));";

            string ConfigFuente = "create table ConfiguracionFuente( NombreForm varchar(50) not null, empleadoID integer not null, nombre varchar(50), tamano varchar(5), unidad varchar(5), gdicharset varchar(5), gdiverticalfont varchar(5), estilo varchar(50) );";

            string ConfigBackcolor = "create table ConfiguracionBackcolor( NombreForm varchar(50) not null, empleadoID integer not null, backcolor varchar(10), backcolorA varchar(5), backcolorR varchar(5), backcolorG varchar(5), backcolorB varchar(5) );";

            string ConfigForecolor = "create table ConfiguracionForecolor( NombreForm varchar(50) not null, empleadoID integer not null, forecolor varchar(10), forecolorA varchar(5), forecolorR varchar(5), forecolorG varchar(5), forecolorB varchar(5) );";

            string forConfigFuente = "ALTER TABLE ConfiguracionFuente ADD CONSTRAINT PK_ConfiguracionFuente PRIMARY KEY CLUSTERED (empleadoID,NombreForm) ;";

            string forConfigBackcolor = "ALTER TABLE ConfiguracionBackcolor ADD CONSTRAINT PK_ConfiguracionBackcolor PRIMARY KEY CLUSTERED (empleadoID,NombreForm) ;";

            string forConfigForecolor = "ALTER TABLE ConfiguracionForecolor ADD CONSTRAINT PK_ConfiguracionForecolor PRIMARY KEY CLUSTERED (empleadoID,NombreForm) ;";

            //la parte de administracion

            //string gruposuario = "CREATE TABLE GRUPOS(CODGRUPO INT NOT NULL IDENTITY(1, 1),DESCRIPCION VARCHAR(30),PRIMARY KEY(CODGRUPO));";

            //string usuario = "CREATE TABLE USUARIOS(CODUSUARIO INT NOT NULL IDENTITY(1, 1),CODGRUPOS INT,CODPERSONAL INT,NOMBREUSUARIO VARCHAR(30),CONTRASENIA VARCHAR(30),ESTADO VARCHAR(20),PRIMARY KEY(CODUSUARIO),FOREIGN KEY(CODGRUPOS) REFERENCES GRUPOS(CODGRUPO),FOREIGN KEY(CODPERSONAL) REFERENCES PERSONAL(CODPERSONAL),);";

            string paquete = "create table PAQUETE(CODPAQUETE INT NOT NULL IDENTITY(1, 1),DESCRIPCIONPAQUETE VARCHAR(30),PRIMARY KEY (CODPAQUETE));";

            string casosdeuso = "CREATE TABLE CASOSDEUSO(CODIGOCASODEUSO INT NOT NULL IDENTITY(1,1),CODPAQUETE INT NOT NULL,DESCRIPCION VARCHAR(30),PRIMARY KEY(CODIGOCASODEUSO),FOREIGN KEY(CODPAQUETE) REFERENCES PAQUETE(CODPAQUETE)ON DELETE CASCADE ON UPDATE CASCADE);";

            string privilegio = "CREATE TABLE PRIVILEGIOS(CODPRIVILEGIO INT NOT NULL IDENTITY(1, 1),CODIGOCASODEUSO INT NOT NULL,DESCRIPCION VARCHAR(30),PRIMARY KEY(CODPRIVILEGIO),FOREIGN KEY(CODIGOCASODEUSO) REFERENCES CASOSDEUSO(CODIGOCASODEUSO));";

            string grupodeprivilegios = "CREATE TABLE GRUPODEPRIVILEGIO(CODGRUPO INT,CODPRIVILEGIO INT,PRIMARY KEY(CODGRUPO, CODPRIVILEGIO),FOREIGN KEY (CODGRUPO) REFERENCES GRUPOS(CODGRUPO)ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY (CODPRIVILEGIO) REFERENCES PRIVILEGIOS (CODPRIVILEGIO)ON DELETE CASCADE ON UPDATE CASCADE);";

            //bitacora--------------

            string bitacora = "create table Bitacora(CodBitacora int not null identity(1, 1), empleadoID int not null, HoraFechaEntrada char(30), HoraFechaSalida char(30), primary key(CodBitacora), foreign key(empleadoID) references Empleado(empleadoID) on delete cascade on update cascade);";
            string detallebitacora = "create table DetalleBitacora(CodDetalleBitacora int not null identity(1, 1),CodBitacora int not null,Operacion varchar(50),HoraOperacion char(20), primary key(CodDetalleBitacora, CodBitacora), foreign key (CodBitacora) references Bitacora(CodBitacora) on delete cascade on update cascade);";


            
            string Proveedor = "create table proveedor( CodProveedor int not null, Nombre varchar(30) not null, Direccion varchar(30) not null, Telefono int not null, primary key (CodProveedor) );";
            string Galpon = "create table galpon ( CodGalpon int not null, Nombre varchar(20) not null, Capacidad int not null, Disponible varchar(1) not null, primary key (CodGalpon) );";
            string Parvada = "create table parvada( CodParvada int not null, Raza varchar(20) not null, primary key (CodParvada) );";

            //para insertar datos de administracion de usuarios

            string InsertPaq1 = "insert into paquete values ('Compras');";
            string InsertPaq2 = "insert into paquete values('Produccion');";

            string InsertCU1 = "insert into casosdeuso values(1, 'Gestionar Proveedor');";
            string InsertCU2 = "insert into casosdeuso values(1, 'Nota de compra de parvada');";
            string InsertCU3 = "insert into casosdeuso values(2, 'Registrar Galpon');";
            string InsertCU4 = "insert into casosdeuso values(2, 'Registrar Parvada');";
            string InsertCU5 = "insert into casosdeuso values(2, 'Lote de Parvada');";


            string InsertPriv1 = "insert into privilegios values(1, 'Nuevo');";
            string InsertPriv2 = "insert into privilegios values(1, 'Guardar');";
            string InsertPriv3 = "insert into privilegios values(2, 'Nuevo');";
            string InsertPriv4 = "insert into privilegios values(2, 'Guardar');";

            string InsertGrupoPriv1 = "insert into grupodeprivilegio values (1,1);";
            string InsertGrupoPriv2 = "insert into grupodeprivilegio values (1,2);";
            string InsertGrupoPriv3 = "insert into grupodeprivilegio values (1,3);";
            string InsertGrupoPriv4 = "insert into grupodeprivilegio values (1,4);";
            string InsertGrupoPriv5 = "insert into grupodeprivilegio values (1,5);";
            string InsertGrupoPriv6 = "insert into grupodeprivilegio values (1,6);";
            string InsertGrupoPriv7 = "insert into grupodeprivilegio values (1,7);";
            string InsertGrupoPriv8 = "insert into grupodeprivilegio values (1,8);";


            SqlCommand myCommand = new SqlCommand(str, myConn);
            SqlCommand myGrupo = new SqlCommand(grupo, myConn);
            SqlCommand myPersona = new SqlCommand(persona, myConn);
            //SqlCommand myContacto = new SqlCommand(contacto, myConn);
            //SqlCommand myCliente = new SqlCommand(cliente, myConn);
            //SqlCommand myForCliente = new SqlCommand(forCliente, myConn);
            SqlCommand myEmpleado = new SqlCommand(empleado, myConn);
            SqlCommand myForEmpleado = new SqlCommand(forEmpleado, myConn);          
            SqlCommand commSesion = new SqlCommand(sesion, myConn);
            SqlCommand commandConfigFuente = new SqlCommand(ConfigFuente, myConn);
            SqlCommand commandConfigBackcolor = new SqlCommand(ConfigBackcolor, myConn);
            SqlCommand commandConfigForecolor = new SqlCommand(ConfigForecolor, myConn);
            SqlCommand commandforConfigFuente = new SqlCommand(forConfigFuente, myConn);
            SqlCommand commandforConfigBackcolor = new SqlCommand(forConfigBackcolor, myConn);
            SqlCommand commandforConfigForecolor = new SqlCommand(forConfigForecolor, myConn);

            //admin
            //SqlCommand commandGrupoUsuario = new SqlCommand(gruposuario, myConn);
            //SqlCommand commandusuario = new SqlCommand(usuario, myConn);
            SqlCommand commandpaquete = new SqlCommand(paquete, myConn);
            SqlCommand commandcasodeuso = new SqlCommand(casosdeuso, myConn);
            SqlCommand commandprivilegio = new SqlCommand(privilegio, myConn);
            SqlCommand commandgrupoprivilegio = new SqlCommand(grupodeprivilegios, myConn);



            SqlCommand commandProveedor = new SqlCommand(Proveedor, myConn);
            SqlCommand commandGalpon = new SqlCommand(Galpon, myConn);
            SqlCommand commandParvada = new SqlCommand(Parvada,myConn);

            //bitacora--------------
            SqlCommand commandbitacora = new SqlCommand(bitacora, myConn);
            SqlCommand commanddetallebitacora = new SqlCommand(detallebitacora, myConn);

            //command insertar admin


            SqlCommand commandInsertPaq1 = new SqlCommand(InsertPaq1, myConn);
            SqlCommand commandInsertPaq2 = new SqlCommand(InsertPaq2, myConn);

            SqlCommand commandInsertCU1 = new SqlCommand(InsertCU1, myConn);
            SqlCommand commandInsertCU2 = new SqlCommand(InsertCU2, myConn);
            SqlCommand commandInsertCU3 = new SqlCommand(InsertCU3, myConn);
            SqlCommand commandInsertCU4 = new SqlCommand(InsertCU4, myConn);
            SqlCommand commandInsertCU5 = new SqlCommand(InsertCU5, myConn);

            SqlCommand commandInsertPriv1 = new SqlCommand(InsertPriv1, myConn);
            SqlCommand commandInsertPriv2 = new SqlCommand(InsertPriv2, myConn);
            SqlCommand commandInsertPriv3 = new SqlCommand(InsertPriv3, myConn);
            SqlCommand commandInsertPriv4 = new SqlCommand(InsertPriv4, myConn);

            SqlCommand commandInsertGrupoPriv1 = new SqlCommand(InsertGrupoPriv1, myConn);
            SqlCommand commandInsertGrupoPriv2 = new SqlCommand(InsertGrupoPriv2, myConn);
            SqlCommand commandInsertGrupoPriv3 = new SqlCommand(InsertGrupoPriv3, myConn);
            SqlCommand commandInsertGrupoPriv4 = new SqlCommand(InsertGrupoPriv4, myConn);
            SqlCommand commandInsertGrupoPriv5 = new SqlCommand(InsertGrupoPriv5, myConn);
            SqlCommand commandInsertGrupoPriv6 = new SqlCommand(InsertGrupoPriv6, myConn);
            SqlCommand commandInsertGrupoPriv7 = new SqlCommand(InsertGrupoPriv7, myConn);
            SqlCommand commandInsertGrupoPriv8 = new SqlCommand(InsertGrupoPriv8, myConn);        


            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myGrupo.ExecuteNonQuery();
                myPersona.ExecuteNonQuery();
                //myContacto.ExecuteNonQuery();
                //myCliente.ExecuteNonQuery();
                //myForCliente.ExecuteNonQuery();
                myEmpleado.ExecuteNonQuery();
                myForEmpleado.ExecuteNonQuery();
                commSesion.ExecuteNonQuery();
                commandConfigFuente.ExecuteNonQuery();
                commandConfigBackcolor.ExecuteNonQuery();
                commandConfigForecolor.ExecuteNonQuery();
                commandforConfigFuente.ExecuteNonQuery();
                commandforConfigBackcolor.ExecuteNonQuery();
                commandforConfigForecolor.ExecuteNonQuery();
                //admin
                //commandGrupoUsuario.ExecuteNonQuery();
                //commandusuario.ExecuteNonQuery();
                commandpaquete.ExecuteNonQuery();
                commandcasodeuso.ExecuteNonQuery();
                commandprivilegio.ExecuteNonQuery();
                commandgrupoprivilegio.ExecuteNonQuery();

                

                commandProveedor.ExecuteNonQuery();
                commandGalpon.ExecuteNonQuery();
                commandParvada.ExecuteNonQuery();

                //bitacora--------------
                commandbitacora.ExecuteNonQuery();
                commanddetallebitacora.ExecuteNonQuery();

                //ejecutar admin

                commandInsertPaq1.ExecuteNonQuery();
                commandInsertPaq2.ExecuteNonQuery();

                commandInsertCU1.ExecuteNonQuery();
                commandInsertCU2.ExecuteNonQuery();
                commandInsertCU3.ExecuteNonQuery();
                commandInsertCU4.ExecuteNonQuery();
                commandInsertCU5.ExecuteNonQuery();

                commandInsertPriv1.ExecuteNonQuery();
                commandInsertPriv2.ExecuteNonQuery();
                commandInsertPriv3.ExecuteNonQuery();
                commandInsertPriv4.ExecuteNonQuery();

                //commandInsertGrupoPriv1.ExecuteNonQuery();
                //commandInsertGrupoPriv2.ExecuteNonQuery();
                //commandInsertGrupoPriv3.ExecuteNonQuery();
                //commandInsertGrupoPriv4.ExecuteNonQuery();
                //commandInsertGrupoPriv5.ExecuteNonQuery();
                //commandInsertGrupoPriv6.ExecuteNonQuery();
                //commandInsertGrupoPriv7.ExecuteNonQuery();
                //commandInsertGrupoPriv8.ExecuteNonQuery();

                MessageBox.Show("se inserto todas la tablas");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public string stringConecction()
        {
            return "data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;";
        }
        public void addUser(int id, string nombres, string direccion, char sexo)
        {
            String str;
            SqlConnection myConn = new SqlConnection("data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;");
            str = "insert into usuario values(" + id + ", '" + nombres + "', '" + direccion + "','" + sexo + "');";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        public void addPA()
        {
            SqlConnection myConn = new SqlConnection("data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;");
            string paPersona = "create proc insertar_Persona @personaID integer,@nombres varchar(30),@apellidos varchar(30),@direccion varchar(30),@sexo char(1),@tipo varchar(20) as declare @id integer select @id =personaID  from Persona where personaID =@personaID if (@id =@personaID )begin print('ya existe persona con id registrado') end else begin insert into Persona values(@personaID ,@nombres ,@apellidos, @direccion ,@sexo ,@tipo )end";
            string paEmpleado = "create proc insertar_Empleado(@empleadoID Integer, @grupoID Integer, @cargo varchar(20), @estado varchar(20), @disponibilidad varchar(20), @nick varchar(20), @password varchar(200)) as insert into Empleado values (@empleadoID, @grupoID, @cargo, @estado, @disponibilidad, @nick,ENCRYPTBYPASSPHRASE('clave' ,@password )); return";
            string paGrupo = "create proc Insertar_Grupo @idgrupo integer,@descripcion varchar(30) as declare @id integer select @id =CODGRUPO from GRUPOS where @idgrupo =CODGRUPO if(@id =@idgrupo ) begin print 'ya existe grupo' End else begin insert into GRUPOS values(@idgrupo ,@descripcion ) end";
            string paPersonaAct = "create proc actualizar_Persona @personaID integer,@nombres varchar(30),@apellidos varchar(30),@direccion varchar(30),@sexo char(1),@tipo varchar(20) as declare @id integer select @id =personaID  from Persona where personaID =@personaID if (@id =@personaID )begin update Persona set nombres =@nombres,apellidos =@apellidos,direccion =@direccion ,sexo =@sexo ,tipo= @tipo  where personaID =@personaID end else begin print('no existe id registrado')end";
            string paPersonaBuscar = "create proc buscar_Persona @personaID integer as select * from Persona where personaID =@personaID ";
            string paPersonaMostrar = "create proc mostrar_Personas as select * from Persona ";
            string paPersonaEliminar = "create proc eliminar_Persona @personaID integer as declare @id integer select @id =personaID  from Persona where personaID =@personaID  if (@id =@personaID )begin delete from Persona where personaID =@personaID end else begin print('no existe id registrado') end";
            string paCliente = "create proc insertar_Cliente @clienteID integer,@tipo varchar(20) as declare @id integer select @id =clienteID   from Cliente  where clienteID  =@clienteID if (@id =@clienteID )begin print('ya existe registro') end else begin insert into Cliente values(@clienteID ,@tipo ) end";
            string paClienteAct = "create proc actualizar_Cliente @clienteID integer,@tipo varchar(20) as declare @id integer select @id =clienteID   from Cliente  where clienteID  =@clienteID if (@id =@clienteID )begin update Cliente set tipo =@tipo where clienteID =@clienteID end else begin print('no existe registro') end";
            string paClienteBuscar = "create proc buscar_Cliente @clienteID integer as select p.personaID as clienteID,p.nombres ,p.apellidos ,p.direccion ,p.sexo ,c.tipo from Cliente c,Persona p where c.clienteID =personaID and c.clienteID =@clienteID order by p.personaID ";
            string paClienteMostrar = "create proc mostrar_Clientes as select p.personaID as clienteID,p.nombres ,p.apellidos ,p.direccion ,p.sexo ,c.tipo from Cliente c,Persona p where c.clienteID =personaID order by p.personaID ";
            string paClienteEliminar = "create proc eliminar_Cliente @clienteID integer as declare @id integer select @id =clienteID   from Cliente  where clienteID  =@clienteID if (@id =@clienteID )begin delete from Cliente where clienteID =@clienteID end else begin print('no existe registro')end";
            string paEmpleadoAct = "create proc actualizar_Empleado(@empleadoID Integer, @grupoID Integer, @cargo varchar(20), @estado varchar(20), @disponibilidad varchar(20)) as update Empleado set grupoID=@grupoID where empleadoID=@empleadoID; update Empleado set cargo=@cargo where empleadoID=@empleadoID; update Empleado set estado=@estado where empleadoID=@empleadoID; update Empleado set disponibildad=@disponibilidad where empleadoID=@empleadoID  return";
            string paEmpleadoBuscar = "create proc buscar_Trabajador(@empleadoID Integer) as select * from Empleado where empleadoID=@empleadoID; return";
            string paEmpleadoMostrar = "create proc mostrar_Trabajadores as select * from Empleado return";
            string paEmpleadoObtenerID = "create proc ID_empleadoSesion(@nick varchar(20),@password varchar(200)) as select empleadoID from Empleado where nick=@nick and DECRYPTBYPASSPHRASE ('clave',password )=@password; return";
            string paEmpleadoBuscar1 = "create proc buscar_Trabajador1 (@empleadoID integer)as select p.personaID as empleadoID,p.nombres, p.apellidos , p.direccion,p.sexo ,e.cargo ,g.descripcion as Grupo,e.disponibildad ,e.estado  from   Empleado e,Persona p,Grupo g where p.personaID =e.empleadoID and e.grupoID =g.grupoID and e.empleadoID =@empleadoID order by p.personaID ";
            string paEmpleadoMostrar1 = "create proc mostrar_Trabajadores1 as select p.personaID as empleadoID,p.nombres, p.apellidos , p.direccion,p.sexo ,e.cargo ,g.descripcion as Grupo,e.disponibildad ,e.estado from   Empleado e,Persona p,Grupo g where p.personaID =e.empleadoID and e.grupoID =g.grupoID order by p.personaID ";

            string paIDGrupo = "create proc ObtenerId_grupo(@descripcion varchar(20))as select CodGrupo from Grupos where descripcion=@descripcion";
            //string paListarLikeRepuestos = "create proc Buscar_ProdusctosListarN(@nombre varchar(50))as begin set  nocount on ;select p.repuestosID   ,p.nombre ,p.precio, p.cantidad  from Repuestos  p where p.nombre   like '%'+ @nombre+'%' end select *from Repuestos ";

            //string paNombreApellidoCliente = "create proc MostrarNombre_Apellido_Cliente(@cipersona integer) as select p.nombres,p.apellidos  from Persona p,Cliente c where p.personaID =c.clienteID and c.clienteID=@cipersona  ";
            //string paNombreApellidoEmpleado = "create proc MostrarNombre_Apellido_Empleado(@cipersona integer) as select p.nombres,p.apellidos  from Persona p,Empleado e where p.personaID =e.empleadoID and e.empleadoID=@cipersona    ";
            
            //string paDevolverIDServicio = "create proc devolverIDServicio(@nombre varchar(50))as select s.servicioID  from Servicio s where s.nombre =@nombre ";
            //string paServcioLike = "create proc Buscar_ServicioLike(@nombre varchar(50))as begin set  nocount on ;select s.servicioID,s.nombre ,s.costo , s.tipo  from Servicio s where s.nombre   like '%'+ @nombre+'%'end  ";
            //string paEmpleadoLike = "create proc Buscar_TrabajadorLike(@nombre varchar(30))as begin set  nocount on ;select p.personaID as empleadoCI,p.nombres,p.apellidos,s.disponibildad from Empleado s,Persona p where p.personaID =s.empleadoID and  s.estado ='Activo' and p.nombres like '%'+ @nombre+'%'end  ";
            
            string padevolverEmpleadoID = "create proc devolverIDEmpleado(@nombre varchar(30))as select e.empleadoID  from Persona p,Empleado e where e.empleadoID =p.personaID and p.nombres =@nombre ";
            

            string paGrupoAct = "create proc Actualizar_Grupo @idgrupo integer,@descripcion varchar(30) as declare @id integer select @id =grupoID from Grupo where @idgrupo =grupoID if(@idgrupo =@id ) begin update Grupo set descripcion=@descripcion where grupoID =@idgrupo End else begin print 'no existe id grupo, intente de nuevo' end";
            string paGrupoBuscar = "create proc Buscar_Grupo @idgrupo integer as select * from Grupo where grupoID=@idgrupo";
            string paGrupoMostrar = "create proc Buscar_Grupos as select * from Grupo";
            string paEliminarGrupo = "create proc EliminarGrupo(@grupoID integer)as delete from Grupo where grupoID =@grupoID ";
            string paNombreGrupo = "create proc ObtenerNombre_grupo(@Id_grupo integer)as select descripcion  from Grupo where grupoID =@Id_grupo ";
            string paDevolverIDGrupo = "create proc devolverIDGrupo(@ciempleado integer)as select grupoID  from Empleado where empleadoID =@ciempleado ";
            string paFuente = "create proc insertar_Fuente(@NombreForm varchar(50),@empleadoID integer,@NombreFuente varchar(50),@TamanoFuente varchar(5),@unidadFuente varchar(5),@charsetFuente varchar(5),@verticalfontFuente varchar(5),@estiloFuente varchar(50)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionFuente where empleadoId=@empleadoID and NombreForm=@NombreForm if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionFuente set nombre=@NombreFuente,tamano=@TamanoFuente,unidad=@unidadFuente,gdicharset=@charsetFuente,gdiverticalfont=@verticalfontFuente,estilo=@estiloFuente where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionFuente values (@NombreForm,@empleadoID,@NombreFuente,@TamanoFuente,@unidadFuente ,@charsetFuente,@verticalfontFuente,@estiloFuente) end return";
            string paFuenteBuscar = "create proc buscar_Fuente(@NombreForm varchar(50), @empleadoID integer) as select * from ConfiguracionFuente where NombreForm=@NombreForm and empleadoID=@empleadoID return";
            string paFuenteMostrar = "create proc mostrar_Fuente as select * from ConfiguracionFuente return";

            string paBackcolor = "create proc insertar_Backcolor(@NombreForm varchar(50),@empleadoID int,@backcolor varchar(10),@backcolorA varchar(5),@backcolorR varchar(5),@backcolorG varchar(5),@backcolorB varchar(5)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionBackcolor where empleadoId=@empleadoID and NombreForm=@NombreForm	if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionBackcolor set backcolor=@backcolor,backcolorA=@backcolorA,backcolorR=@backcolorR,backcolorG=@backcolorG,backcolorB=@backcolorB where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionBackcolor values(@NombreForm,@empleadoID,@backcolor,@backcolorA,@backcolorR ,@backcolorG,@backcolorB) end return";
            string paBackcolorBuscar = "create proc buscar_Backcolor(@empleadoID int,@NombreForm varchar(50)) as select * from ConfiguracionBackcolor where empleadoID=@empleadoID and NombreForm=@NombreForm return";
            string paBackcolorMostrar = "create proc mostrar_Backcolor as select * from ConfiguracionBackcolor return";

            string paForecolor = "create proc insertar_Forecolor(@NombreForm varchar(50),@empleadoID int,@forecolor varchar(10),@forecolorA varchar(5),@forecolorR varchar(5),@forecolorG varchar(5),@forecolorB varchar(5)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionForecolor where empleadoId=@empleadoID and NombreForm=@NombreForm if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionForecolor set forecolor=@forecolor,forecolorA=@forecolorA,forecolorR=@forecolorR,forecolorG=@forecolorG,forecolorB=@forecolorB where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionForecolor values (@NombreForm ,@empleadoID,@forecolor,@forecolorA,@forecolorR ,@forecolorG,@forecolorB) end return";
            string paForecolorBuscar = "create proc buscar_Forecolor(@empleadoID int,@NombreForm varchar(50)) as select * from ConfiguracionForecolor where empleadoID=@empleadoID and NombreForm=@NombreForm return";
            string paForecolorMostrar = "create proc mostrar_Forecolor as select * from ConfiguracionForecolor return";

            //string paFormularioAct = "create proc ModificaFormulario(@idform integer,@habilitado char(1))as declare @id integer select @id=formularioID  from Privilegio where formularioID =@idform  update Formulario set habilitado =@habilitado  where formularioID =@id";
            //string paverHabilidatoForm = "create proc verHabilitad2(@idform integer,@idgrupo integer)as select f.habilitado from Formulario f,Privilegio p,Grupo g where g.grupoID =p.grupoID and p.formularioID=f.formularioID and f.formularioID  =@idform and g.grupoID =@idgrupo group by f.habilitado ";
            //string paAgregarPriv = "create proc agregarPrivilegio(@id integer,@idgrupo integer,@idform integer)as insert into Privilegio values(@id,@idgrupo ,null ,@idform)";
            //string paCargarPriv = "create proc cargarPrivilegio as select *from Privilegio ";

            //administracion de usuarios

            string painsgrupo = "CREATE PROC Insertar_Grupo(@descripcion VARCHAR(30)) AS INSERT INTO GRUPOS VALUES (@descripcion) return";

            string paactgrupo = "CREATE PROC Actualizar_Grupo(@idgrupo INT, @descripcion VARCHAR(30)) AS UPDATE GRUPOS SET DESCRIPCION = @descripcion WHERE CODGRUPO = @idgrupo return";

            string paelimgrupo = "CREATE PROC Eliminar_Grupo(@idgrupo INT) AS DELETE FROM GRUPOS WHERE CODGRUPO = @idgrupo return";

            string pabusgrupo = "CREATE PROC Buscar_Grupos AS	SELECT * FROM GRUPOS return";

            //string paveriusuario = "CREATE PROC Buscar_Grupos AS	SELECT * FROM GRUPOS return";

            string pagetcodusu = "create proc GetCodigoGrupo(@nombre varchar(30), @pass varchar(30)) as	select GRUPOS.CODGRUPO from empleado, GRUPOS where empleado.grupoid= GRUPOS.CODGRUPO and nick = @nombre return";

            string painspaquete = "create proc Insertar_Paquete(@descripcionpaquete varchar(30)) as insert into PAQUETE values(@descripcionpaquete) return";

            string painsgrupriv = "create procedure RegistrarAsignacionPrivilegio(@Grupo varchar(30), @CodPrivilegio int) as declare @CodGrupo int select @CodGrupo =(select  CodGrupo  from GRUPOS  where Descripcion =@Grupo)     INSERT INTO [dbo].GRUPODEPRIVILEGIO([CodGrupo] ,[CodPrivilegio] )       VALUES(@CodGrupo ,@CodPrivilegio ) return";

            string paelimgrupriv = "create proc Eliminar_grupoprivilegio(@codgrupos int) as	delete from GRUPODEPRIVILEGIO where CODGRUPO = @codgrupos return";

            //bitacora--------------
            string paInsertarBitacora = "create proc Insertar_Bitacora(@codusuario int) as declare @entrada char(20) declare @salida char(20) select @entrada = GETDATE() select @salida = GETDATE() insert into Bitacora values(@codusuario, @entrada, @salida) return";
            string paBuscarcodEmpleado = "create proc BuscarEmpleado(@nombreuser varchar(20)) as select Empleado.empleadoID from Empleado where nick = @nombreuser return";
            string paActualizarHoraSalidaBitacora = "create procedure ActualizarHoraSalidaBitacora as begin declare @CodBitacora int select @CodBitacora= MAX(CodBitacora) from Bitacora declare @fecha char(20) select @fecha=GETDATE() update Bitacora set HoraFechaSalida =@fecha where CodBitacora =@CodBitacora end";
            string paMostrarBitacora = "create proc Mostrar_Bitacora as select Bitacora.CodBitacora, DetalleBitacora.CodDetalleBitacora, Empleado.empleadoID, Empleado.nick, DetalleBitacora.Operacion, DetalleBitacora.HoraOperacion,Bitacora.HoraFechaEntrada, Bitacora.HoraFechaSalida from Bitacora, detallebitacora, Empleado where Bitacora.empleadoID= Empleado.empleadoID and Bitacora.CodBitacora= detallebitacora.CodBitacora return";
            string paInsertarDetalleBitacora = "create proc Insertar_DetalleBitacora(@operacion varchar(30)) as	declare @horaoperacion char(20) select @horaoperacion = GETDATE() declare @codbitacora int select @codbitacora =  MAX(CodBitacora) from Bitacora insert into detallebitacora values(@codbitacora, @operacion, @horaoperacion) return";


            string paProveedorInsertar = "create proc insertar_Proveedor(@CodProveedor int, @Nombre varchar(30), @Direccion varchar(30), @Telefono int) as insert into proveedor values (@CodProveedor, @Nombre, @Direccion, @Telefono); return";
            string paGalponInsertar = "create proc insertar_Galpon(@CodGalpon int, @Nombre varchar(20), @Capacidad int, @Disponible varchar(1))as insert into Galpon values (@CodGalpon, @Nombre, @Capacidad, @Disponible); return";
            string paParvadaInsertar = "create proc insertar_Parvada(@CodParvada int, @Raza varchar(20)) as insert into parvada values (@CodParvada, @Raza); return";
            string paParvadaMostrar = "create proc mostrar_Parvadas as select * from parvada; return";

            SqlCommand myPersona = new SqlCommand(paPersona, myConn);
            SqlCommand myEmpleado = new SqlCommand(paEmpleado, myConn);
            //SqlCommand myGrupo = new SqlCommand(paGrupo, myConn);
            //SqlCommand commandPAGrupo = new SqlCommand(paGrupo, myConn);
            //SqlCommand commandPAGrupoAct = new SqlCommand(paGrupoAct, myConn);
            //SqlCommand commandPAGrupoBuscar = new SqlCommand(paGrupoBuscar, myConn);
            //SqlCommand commanndPAGrupoMostrar = new SqlCommand(paGrupoMostrar, myConn);
            
            SqlCommand comPersonaAct = new SqlCommand(paPersonaAct, myConn);
            SqlCommand comPersonaBuscar = new SqlCommand(paPersonaBuscar, myConn);
            SqlCommand comPersonaMostrar = new SqlCommand(paPersonaMostrar, myConn);
            SqlCommand comPersonaEliminar = new SqlCommand(paPersonaEliminar, myConn);
            SqlCommand comCliente = new SqlCommand(paCliente, myConn);
            SqlCommand comClienteAct = new SqlCommand(paClienteAct, myConn);
            SqlCommand comClienteBuscar = new SqlCommand(paClienteBuscar, myConn);
            SqlCommand comClienteMostrar = new SqlCommand(paClienteMostrar, myConn);
            SqlCommand comClienteEliminar = new SqlCommand(paClienteEliminar, myConn);
            //SqlCommand comListarLike = new SqlCommand(paListarLikeRepuestos, myConn);
            //SqlCommand comNombreApellidoCliente = new SqlCommand(paNombreApellidoCliente, myConn);
            //SqlCommand comNombreApellidoEmpleado = new SqlCommand(paNombreApellidoEmpleado, myConn);
            SqlCommand commandPAEmpleadoAct = new SqlCommand(paEmpleadoAct, myConn);
            SqlCommand commandPAEmpleadoBuscar = new SqlCommand(paEmpleadoBuscar, myConn);
            SqlCommand commandPAEmpleadoMostrar = new SqlCommand(paEmpleadoMostrar, myConn);
            SqlCommand commandPAEmpleadoObtenerID = new SqlCommand(paEmpleadoObtenerID, myConn);
            SqlCommand commandPAEmpleadoBuscar1 = new SqlCommand(paEmpleadoBuscar1, myConn);
            SqlCommand commandPAEmpleadoMostrar1 = new SqlCommand(paEmpleadoMostrar1, myConn);
            SqlCommand commanIDGrupo = new SqlCommand(paIDGrupo, myConn);

            //SqlCommand comDevolverIDServicio = new SqlCommand(paDevolverIDServicio, myConn);
            //SqlCommand comServLike = new SqlCommand(paServcioLike, myConn);
            //SqlCommand comEmpleadoLike = new SqlCommand(paEmpleadoLike, myConn);
            SqlCommand comdevolverEmpleadoID = new SqlCommand(padevolverEmpleadoID, myConn);
            
            SqlCommand comNuevo1 = new SqlCommand(paEliminarGrupo, myConn);
            SqlCommand comNuevo4 = new SqlCommand(paDevolverIDGrupo, myConn);
            SqlCommand comNuevo7 = new SqlCommand(paNombreGrupo, myConn);
            SqlCommand commandPAFuente = new SqlCommand(paFuente, myConn);
            SqlCommand commandPAFuenteBuscar = new SqlCommand(paFuenteBuscar, myConn);
            SqlCommand commandPAFuenteMostrar = new SqlCommand(paFuenteMostrar, myConn);
            SqlCommand commandPABackcolor = new SqlCommand(paBackcolor, myConn);
            SqlCommand commandPABackcolorBuscar = new SqlCommand(paBackcolorBuscar, myConn);
            SqlCommand commandPABackcolorMostrar = new SqlCommand(paBackcolorMostrar, myConn);
            SqlCommand commandPAForecolor = new SqlCommand(paForecolor, myConn);
            SqlCommand commandPAForecolorBuscar = new SqlCommand(paForecolorBuscar, myConn);
            SqlCommand commandPAForecolorMostrar = new SqlCommand(paForecolorMostrar, myConn);
            //SqlCommand comNuevo2 = new SqlCommand(paFormularioAct, myConn); ;
            //SqlCommand comNuevo3 = new SqlCommand(paverHabilidatoForm, myConn);
            //SqlCommand comNuevo5 = new SqlCommand(paAgregarPriv, myConn);
            //SqlCommand comNuevo6 = new SqlCommand(paCargarPriv, myConn);

            //administracion de usuario

            SqlCommand commandpainsgrupo = new SqlCommand(painsgrupo, myConn);
            SqlCommand commandpaactgrupo = new SqlCommand(paactgrupo, myConn);
            SqlCommand commandpaelimgrupo = new SqlCommand(paelimgrupo, myConn);
            SqlCommand commandpabusgrupo = new SqlCommand(pabusgrupo, myConn);
            //SqlCommand commandpaveriusuario = new SqlCommand(paveriusuario, myConn);
            SqlCommand commandpagetcodusu = new SqlCommand(pagetcodusu, myConn);
            SqlCommand commandpainspaquete = new SqlCommand(painspaquete, myConn);
            SqlCommand commandpainsgrupriv = new SqlCommand(painsgrupriv, myConn);
            SqlCommand commandpaelimgrupriv = new SqlCommand(paelimgrupriv, myConn);
            SqlCommand commandProveedorInsertar = new SqlCommand(paProveedorInsertar, myConn);
            SqlCommand commandGalponInsertar = new SqlCommand(paGalponInsertar, myConn);
            SqlCommand commandParvadaInsertar = new SqlCommand(paParvadaInsertar,myConn);
            SqlCommand commandParvadaMostrar = new SqlCommand(paParvadaMostrar, myConn);
            //bitacora--------------
            SqlCommand commandpaInsertarBitacora = new SqlCommand(paInsertarBitacora, myConn);
            SqlCommand commandpaBuscarcodEmpleado = new SqlCommand(paBuscarcodEmpleado, myConn);
            SqlCommand commandpaActualizarHoraSalidaBitacora = new SqlCommand(paActualizarHoraSalidaBitacora, myConn);
            SqlCommand commandpaMostrarBitacora = new SqlCommand(paMostrarBitacora, myConn);
            SqlCommand commandpaInsertarDetalleBitacora = new SqlCommand(paInsertarDetalleBitacora, myConn);



            try
            {
                myConn.Open();
                myPersona.ExecuteNonQuery();
                myEmpleado.ExecuteNonQuery();
                //myGrupo.ExecuteNonQuery();
                //commandPAGrupoAct.ExecuteNonQuery();
                //commandPAGrupoBuscar.ExecuteNonQuery();
                //commanndPAGrupoMostrar.ExecuteNonQuery();
                comPersonaAct.ExecuteNonQuery();
                comPersonaBuscar.ExecuteNonQuery();
                comPersonaMostrar.ExecuteNonQuery();
                comPersonaEliminar.ExecuteNonQuery();
                comCliente.ExecuteNonQuery();
                comClienteAct.ExecuteNonQuery();
                comClienteBuscar.ExecuteNonQuery();
                comClienteMostrar.ExecuteNonQuery();
                comClienteEliminar.ExecuteNonQuery();
                
                commandPAEmpleadoAct.ExecuteNonQuery();
                commandPAEmpleadoBuscar.ExecuteNonQuery();
                commandPAEmpleadoMostrar.ExecuteNonQuery();
                commandPAEmpleadoBuscar1.ExecuteNonQuery();
                commandPAEmpleadoMostrar1.ExecuteNonQuery();
                commandPAEmpleadoObtenerID.ExecuteNonQuery();

                commanIDGrupo.ExecuteNonQuery();
                //comListarLike.ExecuteNonQuery();
                //comNombreApellidoCliente.ExecuteNonQuery();
                //comNombreApellidoEmpleado.ExecuteNonQuery();

                //comDevolverIDServicio.ExecuteNonQuery();
                //comServLike.ExecuteNonQuery();
                //comEmpleadoLike.ExecuteNonQuery();
                comdevolverEmpleadoID.ExecuteNonQuery();
                comNuevo1.ExecuteNonQuery();
                comNuevo4.ExecuteNonQuery();
                comNuevo7.ExecuteNonQuery();
                commandPAFuente.ExecuteNonQuery();
                commandPAFuenteBuscar.ExecuteNonQuery();
                commandPAFuenteMostrar.ExecuteNonQuery();
                commandPABackcolor.ExecuteNonQuery();
                commandPABackcolorBuscar.ExecuteNonQuery();
                commandPABackcolorMostrar.ExecuteNonQuery();
                commandPAForecolor.ExecuteNonQuery();
                commandPAForecolorBuscar.ExecuteNonQuery();
                commandPAForecolorMostrar.ExecuteNonQuery();
                //comNuevo2.ExecuteNonQuery();
                //comNuevo3.ExecuteNonQuery();

                //comNuevo5.ExecuteNonQuery();
                //comNuevo6.ExecuteNonQuery();

                //administracion de usuario


   


                //admin pa
                commandpainsgrupo.ExecuteNonQuery();
                commandpaactgrupo.ExecuteNonQuery();
                commandpaelimgrupo.ExecuteNonQuery();
                commandpabusgrupo.ExecuteNonQuery();
                //commandpaveriusuario.ExecuteNonQuery();
                commandpagetcodusu.ExecuteNonQuery();
                commandpainspaquete.ExecuteNonQuery();
                commandpainsgrupriv.ExecuteNonQuery();
                commandpaelimgrupriv.ExecuteNonQuery();

                commandProveedorInsertar.ExecuteNonQuery();
                commandGalponInsertar.ExecuteNonQuery();
                commandParvadaInsertar.ExecuteNonQuery();
                commandParvadaMostrar.ExecuteNonQuery();

                //bitacora--------------
                commandpaInsertarBitacora.ExecuteNonQuery();
                commandpaBuscarcodEmpleado.ExecuteNonQuery();
                commandpaActualizarHoraSalidaBitacora.ExecuteNonQuery();
                commandpaMostrarBitacora.ExecuteNonQuery();
                commandpaInsertarDetalleBitacora.ExecuteNonQuery();

                MessageBox.Show("se inserto todos PA");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
