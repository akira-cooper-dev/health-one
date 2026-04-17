import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import videojs from 'video.js';
import Player from 'video.js/dist/types/player';

export interface VideoPlayerOptions {
  fluid?: boolean,
  fill?: boolean,
  aspectRatio?: string,
  responsive?: boolean,
  controls?: boolean,
  autoplay: boolean,
  sources: {
    src: string,
    type: string,
  }[]
}

@Component({
  selector: 'app-video-player',
  templateUrl: './video-player.component.html',
  styleUrl: './video-player.component.scss',
  standalone: false,
  encapsulation: ViewEncapsulation.None,
})
export class VideoPlayerComponent implements OnInit, OnDestroy {
  @ViewChild('target', { static: true }) target: ElementRef;

  // See options: /guides/options
  @Input() options: VideoPlayerOptions

  videoPlayer: Player;

  constructor(
    private elementRef: ElementRef,
  ) { }

  // Instantiate a Video.js player OnInit
  ngOnInit() {
    this.videoPlayer = videojs(this.target.nativeElement, this.options);
  }

  // Dispose the player OnDestroy
  ngOnDestroy() {
    if (this.videoPlayer) {
      this.videoPlayer.dispose();
    }
  }
}
