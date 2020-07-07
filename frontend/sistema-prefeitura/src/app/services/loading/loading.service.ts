import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ILoadingState } from '../../shared/interfaces/ILoadingState';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private loadingSubject = new Subject<ILoadingState>();

  loadingState = this.loadingSubject.asObservable();

  constructor() { }
  
  show() {
    this.loadingSubject.next(<ILoadingState> { show: true });
  }

  hide() {
    this.loadingSubject.next(<ILoadingState> { show: false });
  }
}
