import { Injectable }    from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';


@Injectable()
export class WatchlistService {

    private watchlistsUrl = 'http://localhost:5002/api/watchlists';

    constructor(private http: Http) { }

    getWatchlist(userId: string): Promise<any> {
        let url = `${this.watchlistsUrl}/${userId}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as any)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}