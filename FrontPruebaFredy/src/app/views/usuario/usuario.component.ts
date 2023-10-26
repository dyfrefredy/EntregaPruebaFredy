import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Usuario } from 'src/app/Interfaces/usuario';
import { TransactionService } from 'src/app/Service/transaction.service';
import { ConstantService } from 'src/app/constant/constant-service';
import { environment } from 'src/environments/environment';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { DialogAddEditComponent } from './dialog-add-edit/dialog-add-edit.component';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})

export class UsuarioComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['nombre', 'fechaNacimiento', 'sexo', 'acciones'];
  dataSource = new MatTableDataSource<Usuario>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private transactionService: TransactionService,
    private constantService: ConstantService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog
  ) { }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.obtenerUsuarios();
  }

  obtenerUsuarios() {
    this.transactionService.getAll(environment.apiUrl, this.constantService.USUARIO_URL).subscribe(
      (data) => {
        console.log(data);

        if (data.responseDto.response === this.constantService.RESPONSE_OK) {
          this.dataSource.data = data.businessDto;
        } else {
          this.mostrarAlerta("No se encontraron usuarios", "Cerrar");
        }
      },
      (error) => {
        this.mostrarAlerta("Error al consultar usuarios", "Cerrar");
      }
    );
  }

  nuevoUsuario(): void {
    const dialogRef = this.dialog.open(DialogAddEditComponent, {
      disableClose: true,
      width: "350px"
    }).afterClosed().subscribe(res => {
      if (res === "creado")
        this.obtenerUsuarios();
    })
  }

  mostrarAlerta(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 3000, // Duración del mensaje en milisegundos
    });
  }
}
