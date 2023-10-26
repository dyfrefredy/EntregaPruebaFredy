import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';
import { Usuario } from 'src/app/Interfaces/usuario';
import { TransactionService } from 'src/app/Service/transaction.service';
import { environment } from 'src/environments/environment';
import { ConstantService } from 'src/app/constant/constant-service';

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY'
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  }
}

@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.scss'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }
  ]
})

export class DialogAddEditComponent {
  formUsuario: FormGroup;
  tituloAccion: string = "Nuevo Usuario";
  botonAccion: string = "Guardar";
  listaSexos = [
    { value: 'F', label: 'Femenino' },
    { value: 'M', label: 'Masculino' }
  ];

  constructor(
    private dialogoReferencia: MatDialogRef<DialogAddEditComponent>,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private transactionService: TransactionService,
    private constantService: ConstantService
  ) {
    this.formUsuario = this.fb.group({
      nombreCompleto: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      sexo: ['', Validators.required]
    })
  }

  agregarNuevoUsuario() {
    console.log(this.formUsuario);
    console.log(this.formUsuario.value);

    const modelo: Usuario = {
      IdDTO: 0,
      NombreDTO: this.formUsuario.value.nombreCompleto,
      FechaNacimientoDTO: this.formUsuario.value.fechaNacimiento,
      SexoDTO: this.formUsuario.value.sexo
    }

    this.transactionService
      .save(environment.apiUrl, this.constantService.USUARIO_URL, modelo)
      .subscribe(
        (data) => {
          if (data.responseDto.response === this.constantService.RESPONSE_OK) {
            this.mostrarAlerta(data.responseDto.message, "Ok");
          } else {
            this.mostrarAlerta(data.responseDto.message, "Alerta");
          }

          this.dialogoReferencia.close("creado");
        },
        (error) => {
          this.mostrarAlerta("Usuario no se agregó correctamente", "Error");
        }
      );
  }

  mostrarAlerta(mensaje: string, accion: string) {
    this._snackBar.open(mensaje, accion, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000, // Duración del mensaje en milisegundos
    });
  }
}
