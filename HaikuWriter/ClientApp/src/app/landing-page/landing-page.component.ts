import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import {HaikuService} from '../service/haiku.service';
import {UserService} from '../service/user.service';
import {User} from '../models/user.model';
import { Haiku } from '../models/haiku.model';
import { GenHaiku} from '../models/gen-haiku.model';
import { SaveHaikuShape} from '../models/save-haiku-shape.model';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  haiku!: Haiku;
  haikuDTO!: GenHaiku;
  savedHaiku = new SaveHaikuShape(" ", " ", " ", " ", " ", " ");

  constructor(private router: Router,
    private userService: UserService,
    private haikuService: HaikuService,
    private route: ActivatedRoute) { }
  
     user = new User(" ", " ", " ", " ", " ", " ", " ", false);

    haikus?: Haiku[];
    writeHaikuSuccess = false;

  ngOnInit(): void {
    //const username = this.route.snapshot.paramMap.get("username")
    const username = localStorage.getItem('User')

    if(username == null){
      this.router.navigateByUrl('/login')
    }
    else{
      this.getUser(username);
    }
    this.getAllHaikus(); 
  }

  getUser(username: string | null){
    this.userService.getUserByUserName(username)
      .subscribe(
        res => {
          this.user = res;
        },
        err => {
          if (err.status === 422) {
            console.log("server serror");
          }
          else{
            console.log("server error");
          }
        }
    );
  }

  getAllHaikus(){
    this.haikuService.getAllHaikus()
      .subscribe(
        res => {
          this.haikus = res;
        },
        err => {
          if (err.status === 422) {
            console.log("server serror");
          }
          else{
            console.log("server error");
          }
        }
    );
  }

  WriteHaiku(){
    this.router.navigateByUrl('/writehaiku');
  }

  GeneHaiku(): void{
    this.haikuService.GeneHaiku()
    .subscribe(res => {
      this.haikuDTO = res;
      console.log(res);
      }
    );
  }

  SaveHaiku(): void{
    const username = localStorage.getItem('User');
    if(username == null){
      return null as any;
    }

    this.savedHaiku.haikuLine1 = this.haikuDTO.haikuLine1;
    this.savedHaiku.haikuLine2 = this.haikuDTO.haikuLine2;
    this.savedHaiku.haikuLine3 = this.haikuDTO.haikuLine3;
    this.savedHaiku.tags = this.haikuDTO.tags;
    this.savedHaiku.username = this.haikuDTO.username;
    this.savedHaiku.currentuser = username;

    this.haikuService.SaveHaiku(this.savedHaiku).subscribe( res => {
      console.log(res);
    });
  }

  // toForum(){

  // }

  logout(){
    localStorage.clear();
    this.router.navigateByUrl('/login')
  }

  
}
