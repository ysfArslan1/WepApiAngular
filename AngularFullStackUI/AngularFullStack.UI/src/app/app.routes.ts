import { Routes } from '@angular/router';
import { BookListComponent } from './features/books/book-list/book-list.component';
import { AddBookComponent } from './features/books/add-book/add-book.component';
import { UpdateBookComponent } from './features/books/update-book/update-book.component';
import { BookDetailComponent } from './features/books/book-detail/book-detail.component';
import { GenreListComponent } from './features/genres/genre-list/genre-list.component';
import { AddGenreComponent } from './features/genres/add-genre/add-genre.component';
import { GenreDetailComponent } from './features/genres/genre-detail/genre-detail.component';
import { GenreUpdateComponent } from './features/genres/genre-update/genre-update.component';
import { AuthorListComponent } from './features/authors/author-list/author-list.component';
import { AuthorDetailComponent } from './features/authors/author-detail/author-detail.component';
import { AuthorAddComponent } from './features/authors/author-add/author-add.component';
import { AuthorUpdateComponent } from './features/authors/author-update/author-update.component';

export const routes: Routes = [
    {
        path:'',
        component:BookListComponent
    },
    {
        path:'books',
        component:BookListComponent
    },
    {
        path:'books/add',
        component:AddBookComponent
    },
    {
        path:'books/update/:id',
        component:UpdateBookComponent
    },
    {
        path:'books/detail/:id',
        component:BookDetailComponent
    },
    {
        path:'genres',
        component:GenreListComponent
    },
    {
        path:'genres/add',
        component:AddGenreComponent
    },
    {
        path:'genres/detail/:id',
        component:GenreDetailComponent
    },
    {
        path:'genres/update/:id',
        component:GenreUpdateComponent
    },
    {
        path:'authors',
        component:AuthorListComponent
    },
    {
        path:'authors/detail/:id',
        component:AuthorDetailComponent
    },
    {
        path:'authors/add',
        component:AuthorAddComponent
    },
    {
        path:'authors/update/:id',
        component:AuthorUpdateComponent
    },
];
