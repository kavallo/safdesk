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
    class Utilidad3
    {
        string nombresDB;

        public Utilidad3(string value)
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

           

            string persona = "CREATE TABLE PERSONA (	 idpersona  int  NOT NULL identity(1, 1),	 ci int not null,	 nombre   varchar (50) NOT NULL,	 direccion   varchar (50) NULL,	 primary key (idpersona));";
            
            //string cliente = "create table CLIENTE(			idcliente int not null			primary key(idcliente),			foreign key(idcliente) references PERSONA(idpersona)			on update cascade on delete cascade);";

            string telf = "";

            string cargo = "CREATE TABLE CARGO (	 idcargo   int  NOT NULL identity(1, 1),	 descripcion  varchar (20) NOT NULL,	 PRIMARY KEY(idcargo) )";

            string departamento = "create table departamento(	iddepartamento int primary key identity(1, 1),	descripcion varchar(80) not null,	nombre varchar(80)not null);";

            //string personal = "CREATE TABLE PERSONAL (	 idpersonal   int  NOT NULL primary key,	 idca int not null,	 idesp int not null,	 foreign key (idpersonal) references persona(idpersona)	 on delete cascade	 on update cascade,	 foreign key (idca) references CARGO(idcargo)	 on delete cascade	 on update cascade,	 foreign key (idesp) references ESPECIALIDAD(idespecialidad)	 on delete cascade	 on update cascade)";

            string personal = "CREATE TABLE PERSONAL (	idpersonal   int  NOT NULL primary key,	 idcargo int not null,	 iddepartamento int not null,	  foreign key (idpersonal) references persona(idpersona) 	 on delete cascade	 on update cascade,		foreign key(idcargo) references cargo(idcargo)	on update cascade on delete no action,	foreign key(iddepartamento) references departamento(iddepartamento)	on update cascade on delete no action);";

            string grupo = "CREATE TABLE GRUPO(CODGRUPO INT NOT NULL IDENTITY(1, 1),DESCRIPCION VARCHAR(30),PRIMARY KEY(CODGRUPO));";

            string usuario = "CREATE TABLE USUARIO(CODUSUARIO INT NOT NULL IDENTITY(1, 1),CODGRUPO INT,CODPERSONAL INT,NOMBREUSUARIO VARCHAR(30),CONTRASENIA varbinary(128),ESTADO VARCHAR(20),PRIMARY KEY(CODUSUARIO),FOREIGN KEY(CODGRUPO) REFERENCES GRUPO(CODGRUPO),FOREIGN KEY(CODPERSONAL) REFERENCES PERSONAL(idpersonal),);";





            string sesion = "create table InicioSesion(sesionID integer primary key,inicio datetime not null,fin datetime not null,empleadoID integer not null,foreign key(empleadoID)references usuario(codusuario));";

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

            string grupodeprivilegios = "CREATE TABLE GRUPODEPRIVILEGIO(CODGRUPO INT,CODPRIVILEGIO INT,PRIMARY KEY(CODGRUPO, CODPRIVILEGIO),FOREIGN KEY (CODGRUPO) REFERENCES GRUPO(CODGRUPO)ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY (CODPRIVILEGIO) REFERENCES PRIVILEGIOS (CODPRIVILEGIO)ON DELETE CASCADE ON UPDATE CASCADE);";

            //bitacora--------------

            string bitacora = "create table Bitacora(CodBitacora int not null identity(1, 1),CodUsuario int not null,HoraFechaEntrada char(30),HoraFechaSalida char(30),primary key(CodBitacora),foreign key(CodUsuario)references Usuario(codusuario) on delete cascade on update cascade);";

            string detallebitacora = "create table DetalleBitacora(CodDetalleBitacora int not null identity(1, 1),CodBitacora int not null,Operacion varchar(50),HoraOperacion char(20),primary key(CodDetalleBitacora, CodBitacora), foreign key (CodBitacora) references Bitacora(CodBitacora)    on delete cascade   on update cascade     		);";


            //las demas tablas



            string atencion = "CREATE TABLE ATENCION (	 idatencion   int  NOT NULL identity(1, 1),	 idpersonal int not null,	 idcliente int not null,	 idmascota int,	 fecha date not null,	 PRIMARY KEY(idatencion),	 foreign key(idpersonal) references PERSONAL(idpersonal),	 foreign key(idcliente) references CLIENTE(idcliente)	 on delete cascade on update cascade	 )";

            string notaventa = "CREATE TABLE NOTAVENTA (	 idnotaventa   int  NOT NULL identity(1, 1)	 idatencion int not null,	 PRIMARY KEY(idnotaventa),	 foreign key(idatencion) references ATENCION(idatencion)	 	 on update cascade on delete cascade)";

            string detallenotaventa = "CREATE TABLE DETALLENOTAVENTA (	 iddetallenotaventa   int  NOT NULL identity(1, 1),	 idnotaventa int not null,	 idlote int not null,	 cantidad int not null,	 precio decimal(12, 2),	 PRIMARY KEY(iddetallenotaventa),	 foreign key(idnotaventa) references NOTAVENTA(idnotaventa)	 	 on update cascade on delete cascade,	 foreign key(idlote) references LOTE(idlote)	 on update cascade on delete cascade)";

            string planpago = "CREATE TABLE PLANPAGO (	 idplanpago   int  NOT NULL identity(1, 1),	 idnotaventa int not null,	 monto decimal(12,2) not null,	 numerodecuotas int null,	 fecha_limite date,	 montodecuaota decimal(12,2) not null,	deuda decimal(12,2)not null,		 estado tinyint not null, 	 PRIMARY KEY(idplanpago),	 foreign key(idnotaventa) references NOTAVENTA(idnotaventa)	 	 on update cascade on delete cascade)";

            string pago = "CREATE TABLE PAGO (	 idpago   int  NOT NULL identity(1, 1),	 idplanpago int not null,	 monto decimal(12,2) not null,	 fechapago date not null,	 PRIMARY KEY(idpago, idplanpago),	 foreign key(idplanpago) references PLANPAGO(idplanpago)	 on update cascade on delete cascade	 )";

            string recibo = "CREATE TABLE RECIBO (	 idrecibo   int  NOT NULL identity(1, 1),	 idplanpago int not null,	 idpago int not null,	 fecha date not null,	 	 monto decimal(12,2) not null,	 	 montocancelado decimal(12,2) not null,	 montocambio decimal(12,2)not null,	 deuda decimal(12,2) not null,	 concepto varchar(50),	 nombre varchar not null,	 primary key(idrecibo),	 foreign key( idpago, idplanpago) references PAGO(idpago, idplanpago)	 	 on update cascade on delete cascade)";

            string servicio = "create table SERVICIO(		idservicio int not null identity(1,1) primary key,		nombre varchar(50)not null,		decimal(12, 2) float not null,		)";

            string servicioestetico = "create table SERVICIOESTETICOS(		idservicioestetico int not null,				primary key(idservicioestetico),		foreign key(idservicioestetico) references SERVICIO(idservicio)		on delete cascade on update cascade)";

            string servicioextra = "create table SERVICIOEXTRAS(		idservicioextra int not null,		primary key(idservicioextra),		foreign key(idservicioextra) references SERVICIO(idservicio)		on delete cascade on update cascade				)";

            string servicioclinico = "";

            string serviciosprestados = "create table SERVICIOSPRESTADOS(		idserviciosprestados int not null identity(1,1),		precio float not null,		idservicio int not null,		idatencion int not null,		primary key(idserviciosprestados),		foreign key(idservicio) references SERVICIO(idservicio)		on delete cascade on update cascade,		foreign key(idatencion) references ATENCION(idatencion)		on delete cascade on update cascade)";

            string productosutilizados = "create table PRODUCTOSUTILIZADOS(			idproductosutilizados int not null identity(1,1),			idlote int not null,			idserviciosprestados int not null,			cantidad int,					primary key(idproductosutilizados),			foreign key(idlote) references LOTE(idlote)			on update cascade on delete cascade,			foreign key(idserviciosprestados) references SERVICIOSPRESTADOS(idserviciosprestados)			on update cascade on delete cascade			)";







            SqlCommand myPersona = new SqlCommand(persona, myConn);
            //SqlCommand myCliente = new SqlCommand(cliente, myConn);
            
            SqlCommand mycargo = new SqlCommand(cargo, myConn);
            SqlCommand mydepartamento = new SqlCommand(departamento, myConn);
            SqlCommand mypersonal = new SqlCommand(personal, myConn);
            SqlCommand mygrupousuario = new SqlCommand(grupo, myConn);
            SqlCommand myusuario = new SqlCommand(usuario, myConn);
            
            
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



            //bitacora--------------
            SqlCommand commandbitacora = new SqlCommand(bitacora, myConn);
            SqlCommand commanddetallebitacora = new SqlCommand(detallebitacora, myConn);


            //las demas tablas


            //SqlCommand clientecom = new SqlCommand(cliente, myConn);
            SqlCommand pedidocom;
            SqlCommand detallepedidocom;
            SqlCommand notacompracom;
            SqlCommand detallenotacompracom;
            SqlCommand ingresocom;
            SqlCommand lotecom;
            SqlCommand atencioncom = new SqlCommand(atencion, myConn);


     


            try
            {
                myConn.Open();
                
                myPersona.ExecuteNonQuery();                
                //myCliente.ExecuteNonQuery();
                
                mycargo.ExecuteNonQuery();
                mydepartamento.ExecuteNonQuery();
                mypersonal.ExecuteNonQuery();
                mygrupousuario.ExecuteNonQuery();
                myusuario.ExecuteNonQuery();

                
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

                

           

                //bitacora--------------
                commandbitacora.ExecuteNonQuery();
                commanddetallebitacora.ExecuteNonQuery();


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

        public void insDatos()
        {
            SqlConnection myConn = new SqlConnection("data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;");

            
            string dato2 = "insert into CARGO values('Administrador');";
            string dato3 = "insert into departamento values ('contabilizar los bienes', 'Contable');";


            
            SqlCommand cdato2 = new SqlCommand(dato2, myConn);
            SqlCommand cdato3 = new SqlCommand(dato3, myConn);

            try
            {
                myConn.Open();

                
                cdato2.ExecuteNonQuery();
                cdato3.ExecuteNonQuery();
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

        public void insPA()
        {
            SqlConnection myConn = new SqlConnection("data source=localhost; initial catalog=" + nombresDB + "; integrated security=True;");



            //string paPersonal = "create proc Insertar_Personal(@ci int, @nombre varchar(50), @direccion varchar(50), @idcargo int, @idespecialidad int) as	declare @idpersonal int 	declare @cantidadCiPersona int	select @cantidadCiPersona = (select count(ci) from PERSONA where @ci = ci)	if @cantidadCiPersona = 0 begin	insert into PERSONA values(@ci, @nombre, @direccion)	select @idpersonal =(select idpersona from PERSONA where @ci = ci)	insert into PERSONAL values(@idpersonal, @idcargo, @idespecialidad)	end	else 		print 'ci duplicado'			return";

            string paPersonal = "create proc Insertar_Personal(@ci int, @nombre varchar(50), @direccion varchar(50), @idcargo int, @iddepartamento int) as	declare @idpersonal int 	declare @cantidadCiPersona int	select @cantidadCiPersona = (select count(ci) from PERSONA where @ci = ci)	if @cantidadCiPersona = 0 begin	insert into PERSONA values(@ci, @nombre, @direccion)		select @idpersonal =(select idpersona from PERSONA where @ci = ci)		insert into PERSONAL values(@idpersonal, @idcargo, @iddepartamento)		end		else 			print 'ci duplicado'			return";
            
            string paUsuario = "create proc Insertar_Usuario(@codgrupo Integer, @codpersonal Integer, @nick varchar(30), @password varchar(200),  @estado varchar(20)) as insert into USUARIO values (@codgrupo, @codpersonal, @nick,ENCRYPTBYPASSPHRASE('clave' ,@password ), @estado); return";

            string paGrupo = "CREATE PROC Insertar_Grupo(@descripcion VARCHAR(30)) AS BEGIN	INSERT INTO GRUPO VALUES (@descripcion)END";

            string paIDGrupo = "create proc ObtenerId_grupo(@descripcion varchar(20))as select CodGrupo from Grupo where descripcion=@descripcion";

            string paDevolverIDGrupo = "create proc devolverIDGrupo(@ciempleado integer)as select codgrupo  from usuario where codusuario =@ciempleado ";

            string pagetcodusu = "create proc GetCodigoGrupo(@nombre varchar(30), @pass varchar(30)) as	select GRUPO.CODGRUPO from usuario, GRUPO where usuario.codgrupo= GRUPO.CODGRUPO and nombreusuario = @nombre return";
            string paInsertarBitacora = "create proc Insertar_Bitacora(@codusuario int) as declare @entrada char(20) declare @salida char(20) select @entrada = GETDATE() select @salida = GETDATE() insert into Bitacora values(@codusuario, @entrada, @salida) return";


            string paEmpleadoObtenerID = "create proc ID_empleadoSesion(@nick varchar(20),@password varchar(200)) as select codusuario from usuario where nombreusuario=@nick and DECRYPTBYPASSPHRASE ('clave',contrasenia )=@password; return";
            string paFuente = "create proc insertar_Fuente(@NombreForm varchar(50),@empleadoID integer,@NombreFuente varchar(50),@TamanoFuente varchar(5),@unidadFuente varchar(5),@charsetFuente varchar(5),@verticalfontFuente varchar(5),@estiloFuente varchar(50)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionFuente where empleadoId=@empleadoID and NombreForm=@NombreForm if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionFuente set nombre=@NombreFuente,tamano=@TamanoFuente,unidad=@unidadFuente,gdicharset=@charsetFuente,gdiverticalfont=@verticalfontFuente,estilo=@estiloFuente where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionFuente values (@NombreForm,@empleadoID,@NombreFuente,@TamanoFuente,@unidadFuente ,@charsetFuente,@verticalfontFuente,@estiloFuente) end return";
            string paFuenteBuscar = "create proc buscar_Fuente(@NombreForm varchar(50), @empleadoID integer) as select * from ConfiguracionFuente where NombreForm=@NombreForm and empleadoID=@empleadoID return";
            string paFuenteMostrar = "create proc mostrar_Fuente as select * from ConfiguracionFuente return";

            string paBackcolor = "create proc insertar_Backcolor(@NombreForm varchar(50),@empleadoID int,@backcolor varchar(10),@backcolorA varchar(5),@backcolorR varchar(5),@backcolorG varchar(5),@backcolorB varchar(5)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionBackcolor where empleadoId=@empleadoID and NombreForm=@NombreForm	if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionBackcolor set backcolor=@backcolor,backcolorA=@backcolorA,backcolorR=@backcolorR,backcolorG=@backcolorG,backcolorB=@backcolorB where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionBackcolor values(@NombreForm,@empleadoID,@backcolor,@backcolorA,@backcolorR ,@backcolorG,@backcolorB) end return";
            string paBackcolorBuscar = "create proc buscar_Backcolor(@empleadoID int,@NombreForm varchar(50)) as select * from ConfiguracionBackcolor where empleadoID=@empleadoID and NombreForm=@NombreForm return";
            string paBackcolorMostrar = "create proc mostrar_Backcolor as select * from ConfiguracionBackcolor return";

            string paForecolor = "create proc insertar_Forecolor(@NombreForm varchar(50),@empleadoID int,@forecolor varchar(10),@forecolorA varchar(5),@forecolorR varchar(5),@forecolorG varchar(5),@forecolorB varchar(5)) as declare @empleadoCI int declare @formulario varchar(50) select @empleadoCI=empleadoId, @formulario=NombreForm from ConfiguracionForecolor where empleadoId=@empleadoID and NombreForm=@NombreForm if(@empleadoCI=@empleadoID and @formulario=@NombreForm) begin update ConfiguracionForecolor set forecolor=@forecolor,forecolorA=@forecolorA,forecolorR=@forecolorR,forecolorG=@forecolorG,forecolorB=@forecolorB where empleadoID=@empleadoID and NombreForm=@NombreForm End else begin insert into ConfiguracionForecolor values (@NombreForm ,@empleadoID,@forecolor,@forecolorA,@forecolorR ,@forecolorG,@forecolorB) end return";
            string paForecolorBuscar = "create proc buscar_Forecolor(@empleadoID int,@NombreForm varchar(50)) as select * from ConfiguracionForecolor where empleadoID=@empleadoID and NombreForm=@NombreForm return";
            string paForecolorMostrar = "create proc mostrar_Forecolor as select * from ConfiguracionForecolor return";



            string paGrupoAct = "create proc Actualizar_Grupo @idgrupo integer,@descripcion varchar(30) as declare @id integer select @id =codgrupo from Grupo where @idgrupo =codgrupo if(@idgrupo =@id ) begin update Grupo set descripcion=@descripcion where codgrupo =@idgrupo End else begin print 'no existe id grupo, intente de nuevo' end";
            string paGrupoBuscar = "create proc Buscar_Grupo @idgrupo integer as select * from Grupo where codgrupo=@idgrupo";
            string paGrupoMostrar = "create proc Buscar_Grupos as select * from Grupo";


            SqlCommand commandPer = new SqlCommand(paPersonal, myConn);
            SqlCommand commandUsu = new SqlCommand(paUsuario, myConn);

            SqlCommand commandGrupo = new SqlCommand(paGrupo, myConn);

            SqlCommand commanIDGrupo = new SqlCommand(paIDGrupo, myConn);


            SqlCommand comNuevo4 = new SqlCommand(paDevolverIDGrupo, myConn);

            SqlCommand commandpagetcodusu = new SqlCommand(pagetcodusu, myConn);
            SqlCommand commandpaInsertarBitacora = new SqlCommand(paInsertarBitacora, myConn);

            SqlCommand commandPAempleadoID = new SqlCommand(paEmpleadoObtenerID, myConn);
            
            SqlCommand commandPAFuente = new SqlCommand(paFuente, myConn);
            SqlCommand commandPAFuenteBuscar = new SqlCommand(paFuenteBuscar, myConn);
            SqlCommand commandPAFuenteMostrar = new SqlCommand(paFuenteMostrar, myConn);
            SqlCommand commandPABackcolor = new SqlCommand(paBackcolor, myConn);
            SqlCommand commandPABackcolorBuscar = new SqlCommand(paBackcolorBuscar, myConn);
            SqlCommand commandPABackcolorMostrar = new SqlCommand(paBackcolorMostrar, myConn);
            SqlCommand commandPAForecolor = new SqlCommand(paForecolor, myConn);
            SqlCommand commandPAForecolorBuscar = new SqlCommand(paForecolorBuscar, myConn);
            SqlCommand commandPAForecolorMostrar = new SqlCommand(paForecolorMostrar, myConn);


            SqlCommand commandPAgrupoactu= new SqlCommand(paGrupoAct, myConn);
            SqlCommand commandPAgrupobuscar = new SqlCommand(paGrupoBuscar, myConn);
            SqlCommand commandPAgrupoMostrar = new SqlCommand(paGrupoMostrar, myConn);
            
            try
            {
                myConn.Open();

                commandPer.ExecuteNonQuery();
                commandUsu.ExecuteNonQuery();

                commandGrupo.ExecuteNonQuery();

                commanIDGrupo.ExecuteNonQuery();
                
                comNuevo4.ExecuteNonQuery();

                commandpagetcodusu.ExecuteNonQuery();
                commandpaInsertarBitacora.ExecuteNonQuery();

                commandPAempleadoID.ExecuteNonQuery();
                
                commandPAFuente.ExecuteNonQuery();
                commandPAFuenteBuscar.ExecuteNonQuery();
                commandPAFuenteMostrar.ExecuteNonQuery();
                commandPABackcolor.ExecuteNonQuery();
                commandPABackcolorBuscar.ExecuteNonQuery();
                commandPABackcolorMostrar.ExecuteNonQuery();
                commandPAForecolor.ExecuteNonQuery();
                commandPAForecolorBuscar.ExecuteNonQuery();
                commandPAForecolorMostrar.ExecuteNonQuery();


                //commandPAgrupoactu.ExecuteNonQuery();
                //commandPAgrupobuscar.ExecuteNonQuery();
                //commandPAgrupoMostrar.ExecuteNonQuery();

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
