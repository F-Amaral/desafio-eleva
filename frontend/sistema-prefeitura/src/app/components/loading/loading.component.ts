import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingService } from 'src/app/services/loading/loading.service';
import { ILoadingState } from 'src/app/shared/interfaces/ILoadingState';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {

  show = false;
  private subscription: Subscription;

  constructor(
    private loadingService: LoadingService
  ) { }

  ngOnInit() {
    this.subscription = this.loadingService.loadingState
      .subscribe((state: ILoadingState) => {
        this.show = state.show;
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
