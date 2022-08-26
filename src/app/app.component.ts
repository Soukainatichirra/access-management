import { Component } from '@angular/core';
import { User } from './models/gestion-acces';
import { UserService } from './services/gestion-acces.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'User.UI';
  users: User[] = [];
  userToEdit?: User;
  

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService
      .getUseres()
      .subscribe((result: User[]) => (this.users = result ));
  }

  updateUserList(users: User[]) {
    this.users = users;
  }

  initNewUser() {
    this.userToEdit = new User();
  }

  editUser(user: User) {
    this.userToEdit = user;
  }
  deleteUser(user: User){
    
  }
}