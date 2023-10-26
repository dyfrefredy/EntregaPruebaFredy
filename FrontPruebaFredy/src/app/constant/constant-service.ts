import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class ConstantService {
    public RESPONSE_OK: string = 'OK';
    public RESPONSE_WARNING: string = 'WARNING';

    public USUARIO_URL: string = '/usuario';
}
