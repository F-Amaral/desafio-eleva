import { Injectable } from '@angular/core';
import createAuth0Client from '@auth0/auth0-spa-js';
import Auth0Client from '@auth0/auth0-spa-js/dist/typings/Auth0Client';
import { from, of, Observable, BehaviorSubject, combineLatest, throwError, iif, Subscription } from 'rxjs';
import { tap, catchError, concatMap, shareReplay, map, take } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  refreshSub: Subscription;
  loggedIn: boolean = null;

  private userProfileSubject$ = new BehaviorSubject<any>(null);
  userProfile$ = this.userProfileSubject$.asObservable();
  
  constructor(public router: Router) { }

  auth0Client$: Observable<Auth0Client> = from(
    createAuth0Client({
      domain: "desafio-eleva.us.auth0.com",
      client_id: "kluiVO6od2f8erLLhOODRm49C3x7zGRu",
      redirect_uri: `${window.location.origin}`,
      audience: 'https://localhost:44386/api/v1/'
    })).pipe(shareReplay(1), catchError(err => throwError(err)));

  isAuthenticated$ = this.auth0Client$.pipe(
    concatMap((client: Auth0Client) => from(client.isAuthenticated())),
    tap(res => this.loggedIn = res)
  );

  handleRedirectCallback$ = this.auth0Client$.pipe(
    concatMap((client: Auth0Client) => from(client.handleRedirectCallback())));


  getTokenSilently$(options?): Observable<string> {
    return this.auth0Client$.pipe(concatMap((client: Auth0Client) =>
      from(client.getTokenSilently(options))));
  }

  getUser$(options?): Observable<any> {
    return this.auth0Client$.pipe(
      concatMap((client: Auth0Client) => from(client.getUser(options))),
      tap(user => this.userProfileSubject$.next(user))
    );
  }

  login(redirectPath: string = '/home/dashboard'): Observable<void> {
    return this.auth0Client$.pipe(
      concatMap((client: Auth0Client) =>
        client.loginWithRedirect({
          redirect_uri: `${window.location.origin}`,
          appState: { target: redirectPath }
        })));
  }

  handleAuthCallback(): Observable<{ loggedIn: boolean; targetUrl: string }> {
    return of(window.location.search).pipe(
      concatMap(params =>
        iif(() => params.includes('code=') && params.includes('state='),
          this.handleRedirectCallback$.pipe(concatMap(cbRes =>
            this.isAuthenticated$.pipe(take(1),
              map(loggedIn => ({
                loggedIn,
                targetUrl: cbRes.appState && cbRes.appState.target ? cbRes.appState.target : '/'
              }))))),
          this.isAuthenticated$.pipe(take(1), map(loggedIn => ({ loggedIn, targetUrl: null }))))));
  }

  logout() {
    this.auth0Client$.subscribe((client: Auth0Client) => {
      client.logout({
        client_id: "kluiVO6od2f8erLLhOODRm49C3x7zGRu",
        returnTo: `${window.location.origin}`
      });
    });
  }
}
