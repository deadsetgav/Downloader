using DownloaderDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;
using DownloaderDomain.Entities;

namespace DownloaderUnitTests.MockObjects
{
    public class MockObjectHelper
    {
        
        public MockObjectHelper()
        {
        }



        public JsonDeserializer GetTestJson()
        {
            var jsonString = @"{""Title"":""Lethal Weapon"",""Year"":""1987"",""Rated"":""R"",""Released"":""06 Mar 1987"",""Runtime"":""110 min"",""Genre"":""Action, Thriller"",""Director"":""Richard Donner"",""Writer"":""Shane Black"",""Actors"":""Mel Gibson, Danny Glover, Gary Busey, Mitch Ryan"",""Plot"":""A veteran cop, Murtaugh, is partnered with a young suicidal cop, Riggs. Both having one thing in common; hating working in pairs. Now they must learn to work with one another to stop a gang of drug smugglers."",""Language"":""English"",""Country"":""USA"",""Awards"":""Nominated for 1 Oscar. Another 5 wins & 1 nomination."",""Poster"":""http://ia.media-imdb.com/images/M/MV5BMTU1MDMzOTcxNV5BMl5BanBnXkFtZTcwNDY5NjQyMQ@@._V1_SX300.jpg"",""Metascore"":""67"",""imdbRating"":""7.6"",""imdbVotes"":""153,833"",""imdbID"":""tt0093409"",""Type"":""movie"",""Response"":""True""}";
            return new JsonDeserializer(jsonString);
        }

        #region "RssHelper"
        
        public SyndicationFeed GetSyndicationFeed()
        {
            using (XmlReader reader = XmlReader.Create(SampleFeed()))
            {
                return SyndicationFeed.Load(reader);
            }

        }
        private Stream SampleFeed()
        {
            var memStream = new MemoryStream();
            var streamWriter = new StreamWriter(memStream);
            streamWriter.Write(SampleXml());
            streamWriter.Flush();
            memStream.Position = 0;
                
            return memStream;
        }

        private string SampleXml()
        {

            return @"<?xml version=""1.0""?>
<rss version=""2.0"" xmlns:atom=""http://www.w3.org/2005/Atom"">
   <channel>
	  <title>Torrentz - movies</title>
	  <link>http://torrentz.eu/verified?q=movies</link>
	  <description>movies search</description>
	  <language>en-us</language>
	  <atom:link href=""http://torrentz.eu/feed_verifiedP?q=movies"" rel=""self"" type=""application/rss+xml"" />
	  <item>
		 <title>The Machine 2014 DVDRIP XVID AC3 ACAB</title>
		 <link>http://torrentz.eu/61a13b0974742f8f2f2e0c610a352a50ebb0f9fb</link>
		 <guid>http://torrentz.eu/61a13b0974742f8f2f2e0c610a352a50ebb0f9fb</guid>
		 <pubDate>Mon, 07 Apr 2014 18:20:18 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1544 MB Seeds: 15,036 Peers: 9,770 Hash: 61a13b0974742f8f2f2e0c610a352a50ebb0f9fb</description>
	  </item>
	  <item>
		 <title>We Are Explorers 3D Printed Video</title>
		 <link>http://torrentz.eu/c022d271812e073eac52a8a389342172889f638e</link>
		 <guid>http://torrentz.eu/c022d271812e073eac52a8a389342172889f638e</guid>
		 <pubDate>Fri, 28 Mar 2014 23:41:05 +0000</pubDate>
		 <category>movies</category>
		 <description>Size: 327 MB Seeds: 22,351 Peers: 46 Hash: c022d271812e073eac52a8a389342172889f638e</description>
	  </item>
	  <item>
		 <title>Sparks 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/852a77b9a4e3a3c4a5b3abf1bfc47fb7e5035095</link>
		 <guid>http://torrentz.eu/852a77b9a4e3a3c4a5b3abf1bfc47fb7e5035095</guid>
		 <pubDate>Mon, 07 Apr 2014 19:19:01 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 754 MB Seeds: 12,731 Peers: 5,604 Hash: 852a77b9a4e3a3c4a5b3abf1bfc47fb7e5035095</description>
	  </item>
	  <item>
		 <title>Frozen 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/4956a4e976ea948025c3c3554567ca2820f65f64</link>
		 <guid>http://torrentz.eu/4956a4e976ea948025c3c3554567ca2820f65f64</guid>
		 <pubDate>Thu, 27 Feb 2014 06:40:37 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1673 MB Seeds: 14,777 Peers: 1,829 Hash: 4956a4e976ea948025c3c3554567ca2820f65f64</description>
	  </item>
	  <item>
		 <title>The Hobbit The Desolation of Smaug 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d61abdbd6a17d5fa2f116078a2fa20f02b07af8f</link>
		 <guid>http://torrentz.eu/d61abdbd6a17d5fa2f116078a2fa20f02b07af8f</guid>
		 <pubDate>Wed, 19 Mar 2014 06:57:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 2106 MB Seeds: 13,037 Peers: 2,450 Hash: d61abdbd6a17d5fa2f116078a2fa20f02b07af8f</description>
	  </item>
	  <item>
		 <title>Ride Along 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/33872fe56515f5b51c079e1cbc59f91a541ad1fb</link>
		 <guid>http://torrentz.eu/33872fe56515f5b51c079e1cbc59f91a541ad1fb</guid>
		 <pubDate>Thu, 03 Apr 2014 22:12:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 757 MB Seeds: 11,792 Peers: 2,111 Hash: 33872fe56515f5b51c079e1cbc59f91a541ad1fb</description>
	  </item>
	  <item>
		 <title>47 Ronin 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/533226d494a43cffd584470f55780cab03c30f05</link>
		 <guid>http://torrentz.eu/533226d494a43cffd584470f55780cab03c30f05</guid>
		 <pubDate>Thu, 20 Mar 2014 21:10:11 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1894 MB Seeds: 11,017 Peers: 2,163 Hash: 533226d494a43cffd584470f55780cab03c30f05</description>
	  </item>
	  <item>
		 <title>The Nut Job 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/32b528bfcd7ebaf5a410946124d5aa5c3c96e7d7</link>
		 <guid>http://torrentz.eu/32b528bfcd7ebaf5a410946124d5aa5c3c96e7d7</guid>
		 <pubDate>Thu, 03 Apr 2014 22:56:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 701 MB Seeds: 10,214 Peers: 2,045 Hash: 32b528bfcd7ebaf5a410946124d5aa5c3c96e7d7</description>
	  </item>
	  <item>
		 <title>300 Rise Of An Empire HC Webrip x264 AC3 TiTAN</title>
		 <link>http://torrentz.eu/cab39350ad77ef3bba647118602446b6490185a1</link>
		 <guid>http://torrentz.eu/cab39350ad77ef3bba647118602446b6490185a1</guid>
		 <pubDate>Sat, 22 Mar 2014 07:21:03 +0000</pubDate>
		 <category>movies h 264 x264</category>
		 <description>Size: 930 MB Seeds: 10,585 Peers: 1,210 Hash: cab39350ad77ef3bba647118602446b6490185a1</description>
	  </item>
	  <item>
		 <title>Drafthouse Films The Act Of Killing **Promotional PREVIEW Bundle **</title>
		 <link>http://torrentz.eu/d6c00ee36ae6e0c63ded038b6e0f1b9497035979</link>
		 <guid>http://torrentz.eu/d6c00ee36ae6e0c63ded038b6e0f1b9497035979</guid>
		 <pubDate>Mon, 06 Jan 2014 09:19:06 +0000</pubDate>
		 <category>movies</category>
		 <description>Size: 1284 MB Seeds: 11,481 Peers: 44 Hash: d6c00ee36ae6e0c63ded038b6e0f1b9497035979</description>
	  </item>
	  <item>
		 <title>Vamp U 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d8029dc501e2c6ddeea9a927170ae5c240ff7483</link>
		 <guid>http://torrentz.eu/d8029dc501e2c6ddeea9a927170ae5c240ff7483</guid>
		 <pubDate>Mon, 07 Apr 2014 10:32:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1469 MB Seeds: 6,869 Peers: 4,205 Hash: d8029dc501e2c6ddeea9a927170ae5c240ff7483</description>
	  </item>
	  <item>
		 <title>Space Pirate Captain Harlock 2013 BRRip XviD AQOS</title>
		 <link>http://torrentz.eu/2b2136c3c2b8c245582bf66cebfcce6d65fea310</link>
		 <guid>http://torrentz.eu/2b2136c3c2b8c245582bf66cebfcce6d65fea310</guid>
		 <pubDate>Tue, 08 Apr 2014 21:47:00 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 904 MB Seeds: 5,231 Peers: 5,517 Hash: 2b2136c3c2b8c245582bf66cebfcce6d65fea310</description>
	  </item>
	  <item>
		 <title>The Machine 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/0220f41ba92dd67d74e7aed4d3557baf8400482f</link>
		 <guid>http://torrentz.eu/0220f41ba92dd67d74e7aed4d3557baf8400482f</guid>
		 <pubDate>Tue, 08 Apr 2014 07:44:01 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 701 MB Seeds: 6,895 Peers: 3,666 Hash: 0220f41ba92dd67d74e7aed4d3557baf8400482f</description>
	  </item>
	  <item>
		 <title>Thor: The Dark World 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6393195b9986c748e4f8e7ccb4f10c72f6ce7bbc</link>
		 <guid>http://torrentz.eu/6393195b9986c748e4f8e7ccb4f10c72f6ce7bbc</guid>
		 <pubDate>Thu, 06 Feb 2014 07:30:01 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 1678 MB Seeds: 9,253 Peers: 1,013 Hash: 6393195b9986c748e4f8e7ccb4f10c72f6ce7bbc</description>
	  </item>
	  <item>
		 <title>The Secret Life of Walter Mitty 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/8b434b411b8cf5caccf5053944448dca8efb2431</link>
		 <guid>http://torrentz.eu/8b434b411b8cf5caccf5053944448dca8efb2431</guid>
		 <pubDate>Thu, 27 Mar 2014 12:23:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 865 MB Seeds: 8,021 Peers: 1,376 Hash: 8b434b411b8cf5caccf5053944448dca8efb2431</description>
	  </item>
	  <item>
		 <title>Gravity 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/95731ce3c5ea065766f6eb92c9a426a58ada56fe</link>
		 <guid>http://torrentz.eu/95731ce3c5ea065766f6eb92c9a426a58ada56fe</guid>
		 <pubDate>Fri, 07 Feb 2014 07:31:00 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 1275 MB Seeds: 8,709 Peers: 673 Hash: 95731ce3c5ea065766f6eb92c9a426a58ada56fe</description>
	  </item>
	  <item>
		 <title>Anchorman 2 The Legend Continues 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/c820dc04aa76cbb582f63b716231407d738c123c</link>
		 <guid>http://torrentz.eu/c820dc04aa76cbb582f63b716231407d738c123c</guid>
		 <pubDate>Sun, 23 Mar 2014 13:39:00 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 868 MB Seeds: 8,322 Peers: 953 Hash: c820dc04aa76cbb582f63b716231407d738c123c</description>
	  </item>
	  <item>
		 <title>Frozen 2013 DVDSCR XViD AC3 FiNGERBLaST</title>
		 <link>http://torrentz.eu/3535a1a6375a619507141c7975611740455e1954</link>
		 <guid>http://torrentz.eu/3535a1a6375a619507141c7975611740455e1954</guid>
		 <pubDate>Tue, 07 Jan 2014 19:37:04 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1479 MB Seeds: 7,910 Peers: 1,006 Hash: 3535a1a6375a619507141c7975611740455e1954</description>
	  </item>
	  <item>
		 <title>Captain America The Winter Soldier 2014 CAM XviD SUMO</title>
		 <link>http://torrentz.eu/87f9975221a833ee7b9d60394b7328489e2fdc05</link>
		 <guid>http://torrentz.eu/87f9975221a833ee7b9d60394b7328489e2fdc05</guid>
		 <pubDate>Fri, 04 Apr 2014 19:57:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 765 MB Seeds: 5,669 Peers: 2,918 Hash: 87f9975221a833ee7b9d60394b7328489e2fdc05</description>
	  </item>
	  <item>
		 <title>Noah 2014 ENGLISH AUDIO CAM XviD MP3 RARBG</title>
		 <link>http://torrentz.eu/d1e5cf113336c8a10f3e50c154504bdd4965cd21</link>
		 <guid>http://torrentz.eu/d1e5cf113336c8a10f3e50c154504bdd4965cd21</guid>
		 <pubDate>Sat, 05 Apr 2014 18:39:01 +0000</pubDate>
		 <category>movies video</category>
		 <description>Size: 1109 MB Seeds: 5,354 Peers: 2,435 Hash: d1e5cf113336c8a10f3e50c154504bdd4965cd21</description>
	  </item>
	  <item>
		 <title>The Hobbit The Desolation of Smaug 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/8ed5613286dcfe9b5c9380839ff01c0e3e93bba4</link>
		 <guid>http://torrentz.eu/8ed5613286dcfe9b5c9380839ff01c0e3e93bba4</guid>
		 <pubDate>Tue, 18 Mar 2014 22:58:04 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 993 MB Seeds: 6,101 Peers: 1,124 Hash: 8ed5613286dcfe9b5c9380839ff01c0e3e93bba4</description>
	  </item>
	  <item>
		 <title>Need For Speed 2014 720p HDTS x264 Pimp4003</title>
		 <link>http://torrentz.eu/a0eba008afebc27719fd31f4d0cf29931c24b73a</link>
		 <guid>http://torrentz.eu/a0eba008afebc27719fd31f4d0cf29931c24b73a</guid>
		 <pubDate>Fri, 28 Mar 2014 15:00:32 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 2025 MB Seeds: 4,961 Peers: 2,152 Hash: a0eba008afebc27719fd31f4d0cf29931c24b73a</description>
	  </item>
	  <item>
		 <title>Captain Phillips 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6041818de2d64fea82405bba08b52d3f10b0f89c</link>
		 <guid>http://torrentz.eu/6041818de2d64fea82405bba08b52d3f10b0f89c</guid>
		 <pubDate>Sat, 11 Jan 2014 09:20:07 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1993 MB Seeds: 6,562 Peers: 536 Hash: 6041818de2d64fea82405bba08b52d3f10b0f89c</description>
	  </item>
	  <item>
		 <title>47 Ronin 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/3dc049453f2a0e378e6f9fb56083269b56045de4</link>
		 <guid>http://torrentz.eu/3dc049453f2a0e378e6f9fb56083269b56045de4</guid>
		 <pubDate>Thu, 20 Mar 2014 15:49:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 869 MB Seeds: 6,036 Peers: 1,028 Hash: 3dc049453f2a0e378e6f9fb56083269b56045de4</description>
	  </item>
	  <item>
		 <title>Divergent 2014 CAM XVID READNFO EVE</title>
		 <link>http://torrentz.eu/7a096737b1288be3c441639798bf5b1ea63c020f</link>
		 <guid>http://torrentz.eu/7a096737b1288be3c441639798bf5b1ea63c020f</guid>
		 <pubDate>Mon, 24 Mar 2014 06:44:01 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 1596 MB Seeds: 4,747 Peers: 2,139 Hash: 7a096737b1288be3c441639798bf5b1ea63c020f</description>
	  </item>
	  <item>
		 <title>The Cure 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d07acd54f7d6583eac438981caf146a195787324</link>
		 <guid>http://torrentz.eu/d07acd54f7d6583eac438981caf146a195787324</guid>
		 <pubDate>Thu, 03 Apr 2014 20:24:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1269 MB Seeds: 5,016 Peers: 1,360 Hash: d07acd54f7d6583eac438981caf146a195787324</description>
	  </item>
	  <item>
		 <title>Dallas Buyers Club 2013 BRRip XviD AC3 WAR</title>
		 <link>http://torrentz.eu/5cd6dc7a993658b0168e3241c090d5eba269482c</link>
		 <guid>http://torrentz.eu/5cd6dc7a993658b0168e3241c090d5eba269482c</guid>
		 <pubDate>Fri, 24 Jan 2014 15:02:01 +0000</pubDate>
		 <category>brrip movies divx xvid video</category>
		 <description>Size: 1484 MB Seeds: 5,150 Peers: 1,057 Hash: 5cd6dc7a993658b0168e3241c090d5eba269482c</description>
	  </item>
	  <item>
		 <title>The Monkey King 2014 720p BRRip x264 AC3 JYK</title>
		 <link>http://torrentz.eu/3a3b4d36baf546badb02a8bfde59dff8111294b9</link>
		 <guid>http://torrentz.eu/3a3b4d36baf546badb02a8bfde59dff8111294b9</guid>
		 <pubDate>Thu, 03 Apr 2014 12:20:21 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 2730 MB Seeds: 4,081 Peers: 2,035 Hash: 3a3b4d36baf546badb02a8bfde59dff8111294b9</description>
	  </item>
	  <item>
		 <title>Grudge Match 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/634b31e371ae68d8fb5a603c901ec19c609e7a5d</link>
		 <guid>http://torrentz.eu/634b31e371ae68d8fb5a603c901ec19c609e7a5d</guid>
		 <pubDate>Wed, 26 Mar 2014 22:12:25 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1683 MB Seeds: 5,304 Peers: 795 Hash: 634b31e371ae68d8fb5a603c901ec19c609e7a5d</description>
	  </item>
	  <item>
		 <title>Frozen 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/25b4cd46e389e96f80ee42e418cd89d3a65ecd66</link>
		 <guid>http://torrentz.eu/25b4cd46e389e96f80ee42e418cd89d3a65ecd66</guid>
		 <pubDate>Thu, 27 Feb 2014 06:40:38 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 805 MB Seeds: 5,433 Peers: 652 Hash: 25b4cd46e389e96f80ee42e418cd89d3a65ecd66</description>
	  </item>
	  <item>
		 <title>The Pirate Fairy 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/bc74f12209be2f0af2d518b9a5ecfcbce8177660</link>
		 <guid>http://torrentz.eu/bc74f12209be2f0af2d518b9a5ecfcbce8177660</guid>
		 <pubDate>Thu, 20 Mar 2014 19:00:57 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 690 MB Seeds: 4,759 Peers: 1,325 Hash: bc74f12209be2f0af2d518b9a5ecfcbce8177660</description>
	  </item>
	  <item>
		 <title>I, Frankenstein 2014 DVDRiP DiVX MP3 ART3MiS</title>
		 <link>http://torrentz.eu/d36360b830eedaa97a63bab8c47a4be272da4bd7</link>
		 <guid>http://torrentz.eu/d36360b830eedaa97a63bab8c47a4be272da4bd7</guid>
		 <pubDate>Fri, 28 Feb 2014 17:41:46 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1047 MB Seeds: 5,323 Peers: 514 Hash: d36360b830eedaa97a63bab8c47a4be272da4bd7</description>
	  </item>
	  <item>
		 <title>300 Rise of an Empire 2014 Subbed HDRip XViD juggs ETRG</title>
		 <link>http://torrentz.eu/61bb343dd902de1ae0ab39eb8a367b115eca729a</link>
		 <guid>http://torrentz.eu/61bb343dd902de1ae0ab39eb8a367b115eca729a</guid>
		 <pubDate>Mon, 24 Mar 2014 17:02:23 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1415 MB Seeds: 4,123 Peers: 1,643 Hash: 61bb343dd902de1ae0ab39eb8a367b115eca729a</description>
	  </item>
	  <item>
		 <title>Her 2013 DVDSCR XviD MP3 RARBG</title>
		 <link>http://torrentz.eu/72b07bebcb8b47a4d40d8bda817369e3213f486e</link>
		 <guid>http://torrentz.eu/72b07bebcb8b47a4d40d8bda817369e3213f486e</guid>
		 <pubDate>Wed, 08 Jan 2014 18:06:06 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1096 MB Seeds: 5,527 Peers: 155 Hash: 72b07bebcb8b47a4d40d8bda817369e3213f486e</description>
	  </item>
	  <item>
		 <title>Ride Along 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6d33a5b43d4fc8f70bc272667197e24d1b71e99b</link>
		 <guid>http://torrentz.eu/6d33a5b43d4fc8f70bc272667197e24d1b71e99b</guid>
		 <pubDate>Fri, 04 Apr 2014 09:23:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1479 MB Seeds: 4,633 Peers: 1,043 Hash: 6d33a5b43d4fc8f70bc272667197e24d1b71e99b</description>
	  </item>
	  <item>
		 <title>The Secret Life of Walter Mitty 2013 DVDscr XViD NO1KNOWS</title>
		 <link>http://torrentz.eu/0a175ff75b5b62564b2b2c797c126303354c84ee</link>
		 <guid>http://torrentz.eu/0a175ff75b5b62564b2b2c797c126303354c84ee</guid>
		 <pubDate>Thu, 09 Jan 2014 14:29:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1904 MB Seeds: 4,855 Peers: 706 Hash: 0a175ff75b5b62564b2b2c797c126303354c84ee</description>
	  </item>
	  <item>
		 <title>Dallas Buyers Club 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/f18a60db02ec3b55c18924f47955de766dacc537</link>
		 <guid>http://torrentz.eu/f18a60db02ec3b55c18924f47955de766dacc537</guid>
		 <pubDate>Fri, 24 Jan 2014 06:51:01 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 869 MB Seeds: 5,081 Peers: 195 Hash: f18a60db02ec3b55c18924f47955de766dacc537</description>
	  </item>
	  <item>
		 <title>Jackass Presents: Bad Grandpa 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/c3d6b8ef7df03b68a976c06516eb6cfa6b2dc808</link>
		 <guid>http://torrentz.eu/c3d6b8ef7df03b68a976c06516eb6cfa6b2dc808</guid>
		 <pubDate>Sat, 04 Jan 2014 05:57:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 807 MB Seeds: 4,988 Peers: 256 Hash: c3d6b8ef7df03b68a976c06516eb6cfa6b2dc808</description>
	  </item>
	  <item>
		 <title>47 Ronin 2013 DVDRip XviD MAXSPEED</title>
		 <link>http://torrentz.eu/bb2ef671ec8dfe0e59805d0a216df0f250eaad41</link>
		 <guid>http://torrentz.eu/bb2ef671ec8dfe0e59805d0a216df0f250eaad41</guid>
		 <pubDate>Tue, 18 Mar 2014 10:54:01 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 1620 MB Seeds: 4,188 Peers: 978 Hash: bb2ef671ec8dfe0e59805d0a216df0f250eaad41</description>
	  </item>
	  <item>
		 <title>Ride Along 2014 KORSUB HDRip XViD NO1KNOWS</title>
		 <link>http://torrentz.eu/fe74bd8cf6a97bd1785427763ca77fd0850c74b1</link>
		 <guid>http://torrentz.eu/fe74bd8cf6a97bd1785427763ca77fd0850c74b1</guid>
		 <pubDate>Fri, 31 Jan 2014 23:20:01 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 1408 MB Seeds: 4,416 Peers: 651 Hash: fe74bd8cf6a97bd1785427763ca77fd0850c74b1</description>
	  </item>
	  <item>
		 <title>Blood Ties 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/f018abeeadace1ff6184c2147f6610ab99208d5a</link>
		 <guid>http://torrentz.eu/f018abeeadace1ff6184c2147f6610ab99208d5a</guid>
		 <pubDate>Fri, 04 Apr 2014 09:42:06 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 923 MB Seeds: 4,071 Peers: 851 Hash: f018abeeadace1ff6184c2147f6610ab99208d5a</description>
	  </item>
	  <item>
		 <title>Son Of God 2014 WEBRip x264 k3ly P2PDL</title>
		 <link>http://torrentz.eu/fbab939534dba608001ae288109c4f29edf807f1</link>
		 <guid>http://torrentz.eu/fbab939534dba608001ae288109c4f29edf807f1</guid>
		 <pubDate>Sun, 23 Mar 2014 09:27:00 +0000</pubDate>
		 <category>movies h 264 x264</category>
		 <description>Size: 959 MB Seeds: 4,009 Peers: 793 Hash: fbab939534dba608001ae288109c4f29edf807f1</description>
	  </item>
	  <item>
		 <title>About Time 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/60f81b1852a5f687c641f5a1b4c37f4f1406b527</link>
		 <guid>http://torrentz.eu/60f81b1852a5f687c641f5a1b4c37f4f1406b527</guid>
		 <pubDate>Wed, 01 Jan 2014 23:28:03 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 869 MB Seeds: 4,379 Peers: 353 Hash: 60f81b1852a5f687c641f5a1b4c37f4f1406b527</description>
	  </item>
	  <item>
		 <title>Despicable Me 2 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/affc3a2bbb7da2fab119d1c85c20072b394db1cb</link>
		 <guid>http://torrentz.eu/affc3a2bbb7da2fab119d1c85c20072b394db1cb</guid>
		 <pubDate>Fri, 18 Oct 2013 12:50:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1482 MB Seeds: 4,055 Peers: 676 Hash: affc3a2bbb7da2fab119d1c85c20072b394db1cb</description>
	  </item>
	  <item>
		 <title>Saving Mr Banks 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6d0c1395c9f2714282a7eea6e3c738d50ce21c77</link>
		 <guid>http://torrentz.eu/6d0c1395c9f2714282a7eea6e3c738d50ce21c77</guid>
		 <pubDate>Thu, 27 Feb 2014 10:26:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 873 MB Seeds: 4,406 Peers: 324 Hash: 6d0c1395c9f2714282a7eea6e3c738d50ce21c77</description>
	  </item>
	  <item>
		 <title>Anchorman 2 The Legend Continues 2013 HDRip XViD juggs ETRG</title>
		 <link>http://torrentz.eu/03078811cc64869a05340f57d908496fed0307db</link>
		 <guid>http://torrentz.eu/03078811cc64869a05340f57d908496fed0307db</guid>
		 <pubDate>Tue, 11 Mar 2014 10:00:23 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 703 MB Seeds: 4,104 Peers: 619 Hash: 03078811cc64869a05340f57d908496fed0307db</description>
	  </item>
	  <item>
		 <title>The Secret Life of Walter Mitty 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/15eb8ff6f65cb51f59e95f6be55efe22dc70d707</link>
		 <guid>http://torrentz.eu/15eb8ff6f65cb51f59e95f6be55efe22dc70d707</guid>
		 <pubDate>Thu, 27 Mar 2014 22:39:02 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1889 MB Seeds: 3,802 Peers: 833 Hash: 15eb8ff6f65cb51f59e95f6be55efe22dc70d707</description>
	  </item>
	  <item>
		 <title>Paranormal Activity The Marked Ones 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d8c3bbbfd0d0e7f860079ec0bde34b782fe751b2</link>
		 <guid>http://torrentz.eu/d8c3bbbfd0d0e7f860079ec0bde34b782fe751b2</guid>
		 <pubDate>Fri, 28 Mar 2014 09:30:07 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1672 MB Seeds: 3,774 Peers: 695 Hash: d8c3bbbfd0d0e7f860079ec0bde34b782fe751b2</description>
	  </item>
	  <item>
		 <title>Main Tera Hero 2014 Hindi Non Retail DVDRip XviD HTRG</title>
		 <link>http://torrentz.eu/626ead6b10666ad92696af97e4b3e5d326ae46e5</link>
		 <guid>http://torrentz.eu/626ead6b10666ad92696af97e4b3e5d326ae46e5</guid>
		 <pubDate>Fri, 04 Apr 2014 20:04:00 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 695 MB Seeds: 2,896 Peers: 1,548 Hash: 626ead6b10666ad92696af97e4b3e5d326ae46e5</description>
	  </item>
	  <item>
		 <title>The Book Thief 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/17a91d3a06114f42c131dea72ccfc512d772077e</link>
		 <guid>http://torrentz.eu/17a91d3a06114f42c131dea72ccfc512d772077e</guid>
		 <pubDate>Thu, 27 Feb 2014 21:30:27 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 928 MB Seeds: 4,119 Peers: 292 Hash: 17a91d3a06114f42c131dea72ccfc512d772077e</description>
	  </item>
	  <item>
		 <title>World War Z 2013 UNRATED 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/319fc21f3db3254c5bc976a096801ab791458e95</link>
		 <guid>http://torrentz.eu/319fc21f3db3254c5bc976a096801ab791458e95</guid>
		 <pubDate>Tue, 03 Sep 2013 02:56:13 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1886 MB Seeds: 4,032 Peers: 306 Hash: 319fc21f3db3254c5bc976a096801ab791458e95</description>
	  </item>
	  <item>
		 <title>The Wolverine 2013 EXTENDED 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d91fbb667d8f7e9cc653123aabf37bb4851b2270</link>
		 <guid>http://torrentz.eu/d91fbb667d8f7e9cc653123aabf37bb4851b2270</guid>
		 <pubDate>Thu, 07 Nov 2013 13:43:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 2090 MB Seeds: 3,863 Peers: 363 Hash: d91fbb667d8f7e9cc653123aabf37bb4851b2270</description>
	  </item>
	  <item>
		 <title>Ender&#039;s Game 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/a63755cfceb25413ef88face5101b5d457d4bd4d</link>
		 <guid>http://torrentz.eu/a63755cfceb25413ef88face5101b5d457d4bd4d</guid>
		 <pubDate>Thu, 30 Jan 2014 18:16:20 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 1691 MB Seeds: 3,835 Peers: 339 Hash: a63755cfceb25413ef88face5101b5d457d4bd4d</description>
	  </item>
	  <item>
		 <title>Thor: The Dark World 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/420ffa5cb90241d398a75fa6ab314b4d7b7e1eac</link>
		 <guid>http://torrentz.eu/420ffa5cb90241d398a75fa6ab314b4d7b7e1eac</guid>
		 <pubDate>Thu, 06 Feb 2014 05:23:00 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 811 MB Seeds: 3,787 Peers: 371 Hash: 420ffa5cb90241d398a75fa6ab314b4d7b7e1eac</description>
	  </item>
	  <item>
		 <title>Gravity 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/80fe9c2a368afb173812cb3ddd8f1bfac86b762d</link>
		 <guid>http://torrentz.eu/80fe9c2a368afb173812cb3ddd8f1bfac86b762d</guid>
		 <pubDate>Fri, 07 Feb 2014 06:03:04 +0000</pubDate>
		 <category>brrip movies hd</category>
		 <description>Size: 704 MB Seeds: 3,809 Peers: 327 Hash: 80fe9c2a368afb173812cb3ddd8f1bfac86b762d</description>
	  </item>
	  <item>
		 <title>The Devil&#039;s Violinist 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/9dfd8010bb0e1b1742b73020e279880d3ef75581</link>
		 <guid>http://torrentz.eu/9dfd8010bb0e1b1742b73020e279880d3ef75581</guid>
		 <pubDate>Thu, 10 Apr 2014 00:12:01 +0000</pubDate>
		 <category>brrip movies video hd</category>
		 <description>Size: 1895 MB Seeds: 9 Peers: 4,123 Hash: 9dfd8010bb0e1b1742b73020e279880d3ef75581</description>
	  </item>
	  <item>
		 <title>Man of Steel 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6a450b7f275d5b777b2a8d29c92febe26d654909</link>
		 <guid>http://torrentz.eu/6a450b7f275d5b777b2a8d29c92febe26d654909</guid>
		 <pubDate>Wed, 16 Oct 2013 04:06:11 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 2090 MB Seeds: 3,755 Peers: 367 Hash: 6a450b7f275d5b777b2a8d29c92febe26d654909</description>
	  </item>
	  <item>
		 <title>Cloudy with a Chance of Meatballs 2 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/a74fc04f85eb8a697be82feb0687edf83e88802d</link>
		 <guid>http://torrentz.eu/a74fc04f85eb8a697be82feb0687edf83e88802d</guid>
		 <pubDate>Sat, 11 Jan 2014 06:42:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 756 MB Seeds: 3,818 Peers: 304 Hash: a74fc04f85eb8a697be82feb0687edf83e88802d</description>
	  </item>
	  <item>
		 <title>The Hobbit: An Unexpected Journey 2012 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/0653c32f1cd717e5723793f4e422731e581cab87</link>
		 <guid>http://torrentz.eu/0653c32f1cd717e5723793f4e422731e581cab87</guid>
		 <pubDate>Thu, 28 Feb 2013 19:58:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 2560 MB Seeds: 3,507 Peers: 595 Hash: 0653c32f1cd717e5723793f4e422731e581cab87</description>
	  </item>
	  <item>
		 <title>We&#039;re the Millers 2013 EXTENDED 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d183b41af9b6e8612ae61f1177b1f9ab1d16e7c9</link>
		 <guid>http://torrentz.eu/d183b41af9b6e8612ae61f1177b1f9ab1d16e7c9</guid>
		 <pubDate>Thu, 31 Oct 2013 09:36:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 869 MB Seeds: 3,921 Peers: 152 Hash: d183b41af9b6e8612ae61f1177b1f9ab1d16e7c9</description>
	  </item>
	  <item>
		 <title>This Is the End 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/024ddb9b7b8f8b1825eda336b48ebb78d88dc152</link>
		 <guid>http://torrentz.eu/024ddb9b7b8f8b1825eda336b48ebb78d88dc152</guid>
		 <pubDate>Sat, 14 Sep 2013 00:21:38 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 811 MB Seeds: 3,850 Peers: 180 Hash: 024ddb9b7b8f8b1825eda336b48ebb78d88dc152</description>
	  </item>
	  <item>
		 <title>Her 2013 DVDScr XviD SaM ETRG</title>
		 <link>http://torrentz.eu/3e1c0a16b874b9a7a2aebd24d973f360296aa28a</link>
		 <guid>http://torrentz.eu/3e1c0a16b874b9a7a2aebd24d973f360296aa28a</guid>
		 <pubDate>Mon, 13 Jan 2014 14:42:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 717 MB Seeds: 3,162 Peers: 844 Hash: 3e1c0a16b874b9a7a2aebd24d973f360296aa28a</description>
	  </item>
	  <item>
		 <title>The Nut Job 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/76ccec6731da0720e039791637d5dd2463dc8b8a</link>
		 <guid>http://torrentz.eu/76ccec6731da0720e039791637d5dd2463dc8b8a</guid>
		 <pubDate>Fri, 04 Apr 2014 02:10:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1272 MB Seeds: 3,092 Peers: 816 Hash: 76ccec6731da0720e039791637d5dd2463dc8b8a</description>
	  </item>
	  <item>
		 <title>Date and Switch 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/92900651664400a28c02079c8df83dbffaecf1f1</link>
		 <guid>http://torrentz.eu/92900651664400a28c02079c8df83dbffaecf1f1</guid>
		 <pubDate>Wed, 02 Apr 2014 07:32:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 749 MB Seeds: 3,245 Peers: 640 Hash: 92900651664400a28c02079c8df83dbffaecf1f1</description>
	  </item>
	  <item>
		 <title>300 Rise Of An Empire 2014 HC 720p WEBRip x264 AC3 JYK</title>
		 <link>http://torrentz.eu/9776ec986bbe0569bb09be719c59ce7eca4f8f22</link>
		 <guid>http://torrentz.eu/9776ec986bbe0569bb09be719c59ce7eca4f8f22</guid>
		 <pubDate>Mon, 24 Mar 2014 13:00:50 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 1897 MB Seeds: 2,802 Peers: 1,017 Hash: 9776ec986bbe0569bb09be719c59ce7eca4f8f22</description>
	  </item>
	  <item>
		 <title>GLOUBi clochette et la fee pirate french dvdrip 2014</title>
		 <link>http://torrentz.eu/9015cdf3dc09afc89d5bd8a1cc4ef9a765fde415</link>
		 <guid>http://torrentz.eu/9015cdf3dc09afc89d5bd8a1cc4ef9a765fde415</guid>
		 <pubDate>Sat, 22 Mar 2014 12:20:20 +0000</pubDate>
		 <category>movies</category>
		 <description>Size: 702 MB Seeds: 3,569 Peers: 158 Hash: 9015cdf3dc09afc89d5bd8a1cc4ef9a765fde415</description>
	  </item>
	  <item>
		 <title>Veronica Mars 2014 HDRip XviD EVO</title>
		 <link>http://torrentz.eu/f25b41b6714d121a99223dbbe391365842908d34</link>
		 <guid>http://torrentz.eu/f25b41b6714d121a99223dbbe391365842908d34</guid>
		 <pubDate>Fri, 14 Mar 2014 01:23:01 +0000</pubDate>
		 <category>movies video</category>
		 <description>Size: 871 MB Seeds: 3,069 Peers: 627 Hash: f25b41b6714d121a99223dbbe391365842908d34</description>
	  </item>
	  <item>
		 <title>The Counselor 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/dab55343c02471a462c4bc4cbc3feffd18d38443</link>
		 <guid>http://torrentz.eu/dab55343c02471a462c4bc4cbc3feffd18d38443</guid>
		 <pubDate>Thu, 30 Jan 2014 07:29:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 981 MB Seeds: 3,438 Peers: 194 Hash: dab55343c02471a462c4bc4cbc3feffd18d38443</description>
	  </item>
	  <item>
		 <title>Queen 2014 Hindi 720p DVDSCR 999MB ShAaNiG</title>
		 <link>http://torrentz.eu/1ff163994f41df8b7a49007f96fb778287fdad0a</link>
		 <guid>http://torrentz.eu/1ff163994f41df8b7a49007f96fb778287fdad0a</guid>
		 <pubDate>Fri, 28 Mar 2014 07:48:04 +0000</pubDate>
		 <category>movies</category>
		 <description>Size: 999 MB Seeds: 2,354 Peers: 1,272 Hash: 1ff163994f41df8b7a49007f96fb778287fdad0a</description>
	  </item>
	  <item>
		 <title>Bad Country 2014 DVDRip XviD AC3 EVO</title>
		 <link>http://torrentz.eu/c0b50b969ff062a858a3853272d537935e2283f4</link>
		 <guid>http://torrentz.eu/c0b50b969ff062a858a3853272d537935e2283f4</guid>
		 <pubDate>Sat, 08 Mar 2014 19:41:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1415 MB Seeds: 3,096 Peers: 507 Hash: c0b50b969ff062a858a3853272d537935e2283f4</description>
	  </item>
	  <item>
		 <title>Pacific Rim 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/4f178d9782845f20714e5d8b5e05ef68a77e54f9</link>
		 <guid>http://torrentz.eu/4f178d9782845f20714e5d8b5e05ef68a77e54f9</guid>
		 <pubDate>Sun, 06 Oct 2013 11:19:03 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1995 MB Seeds: 3,328 Peers: 271 Hash: 4f178d9782845f20714e5d8b5e05ef68a77e54f9</description>
	  </item>
	  <item>
		 <title>Student Bodies NEW 2014 Sweet Sinner Split Scenes</title>
		 <link>http://torrentz.eu/376cdc8789e6e6c645f6f755642f8b684de7d08a</link>
		 <guid>http://torrentz.eu/376cdc8789e6e6c645f6f755642f8b684de7d08a</guid>
		 <pubDate>Thu, 27 Mar 2014 06:39:03 +0000</pubDate>
		 <category>xxx porn movies</category>
		 <description>Size: 1844 MB Seeds: 2,124 Peers: 1,343 Hash: 376cdc8789e6e6c645f6f755642f8b684de7d08a</description>
	  </item>
	  <item>
		 <title>Dracula The Dark Prince 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/5d6f455a211faba822c52dbb26b6842b9bc6750e</link>
		 <guid>http://torrentz.eu/5d6f455a211faba822c52dbb26b6842b9bc6750e</guid>
		 <pubDate>Thu, 03 Apr 2014 20:15:06 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 757 MB Seeds: 2,776 Peers: 685 Hash: 5d6f455a211faba822c52dbb26b6842b9bc6750e</description>
	  </item>
	  <item>
		 <title>Elysium 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/130c1e9d107b96d6e63dc7fe5ebf1ee59af044e1</link>
		 <guid>http://torrentz.eu/130c1e9d107b96d6e63dc7fe5ebf1ee59af044e1</guid>
		 <pubDate>Tue, 26 Nov 2013 03:03:09 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1684 MB Seeds: 3,239 Peers: 199 Hash: 130c1e9d107b96d6e63dc7fe5ebf1ee59af044e1</description>
	  </item>
	  <item>
		 <title>Avengers Confidential Black Widow And Punisher 2014 HDRip XviD AC3 SaM ETRG</title>
		 <link>http://torrentz.eu/414d4a331a2987c9a564e1f39a1ced79e2101f21</link>
		 <guid>http://torrentz.eu/414d4a331a2987c9a564e1f39a1ced79e2101f21</guid>
		 <pubDate>Tue, 11 Mar 2014 12:40:19 +0000</pubDate>
		 <category>xvid movies divx video</category>
		 <description>Size: 1415 MB Seeds: 2,679 Peers: 745 Hash: 414d4a331a2987c9a564e1f39a1ced79e2101f21</description>
	  </item>
	  <item>
		 <title>Shaadi ke Side Effects 2014 Hindi 720p HDRip x264 AAC Hon3y</title>
		 <link>http://torrentz.eu/8cbe4f6b21a74a7db329f3b9a99b9088d05d42c0</link>
		 <guid>http://torrentz.eu/8cbe4f6b21a74a7db329f3b9a99b9088d05d42c0</guid>
		 <pubDate>Sat, 05 Apr 2014 07:29:00 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 1024 MB Seeds: 1,428 Peers: 1,957 Hash: 8cbe4f6b21a74a7db329f3b9a99b9088d05d42c0</description>
	  </item>
	  <item>
		 <title>Anchorman 2 The Legend Continues 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/ae80c7d0f0ebabbf2582dad984fc763351ab13bd</link>
		 <guid>http://torrentz.eu/ae80c7d0f0ebabbf2582dad984fc763351ab13bd</guid>
		 <pubDate>Sun, 23 Mar 2014 15:33:36 +0000</pubDate>
		 <category>movies hd video</category>
		 <description>Size: 1887 MB Seeds: 2,934 Peers: 438 Hash: ae80c7d0f0ebabbf2582dad984fc763351ab13bd</description>
	  </item>
	  <item>
		 <title>The Book Thief 2013 DVDScr XviD SaM ETRG</title>
		 <link>http://torrentz.eu/6595ebfc003c29448a6facbc1146579c039f3683</link>
		 <guid>http://torrentz.eu/6595ebfc003c29448a6facbc1146579c039f3683</guid>
		 <pubDate>Fri, 10 Jan 2014 21:49:02 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 712 MB Seeds: 2,840 Peers: 470 Hash: 6595ebfc003c29448a6facbc1146579c039f3683</description>
	  </item>
	  <item>
		 <title>The Conjuring 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/374a9448662b6d8073fe54933b52d9fc8e206b93</link>
		 <guid>http://torrentz.eu/374a9448662b6d8073fe54933b52d9fc8e206b93</guid>
		 <pubDate>Tue, 08 Oct 2013 11:32:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1691 MB Seeds: 2,970 Peers: 204 Hash: 374a9448662b6d8073fe54933b52d9fc8e206b93</description>
	  </item>
	  <item>
		 <title>Anchorman 2 The Legend Continues 2013 UNRATED 1080p WEB DL H264 PublicHD</title>
		 <link>http://torrentz.eu/a6efdd9fa2dbbaa1802a3928abf93291387acb68</link>
		 <guid>http://torrentz.eu/a6efdd9fa2dbbaa1802a3928abf93291387acb68</guid>
		 <pubDate>Tue, 11 Mar 2014 06:48:00 +0000</pubDate>
		 <category>bluray 1080p movies hd</category>
		 <description>Size: 3891 MB Seeds: 3,022 Peers: 137 Hash: a6efdd9fa2dbbaa1802a3928abf93291387acb68</description>
	  </item>
	  <item>
		 <title>Iron Man 3 2013 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/70b487b9e21e2869af831397851f45a00d3ea7ca</link>
		 <guid>http://torrentz.eu/70b487b9e21e2869af831397851f45a00d3ea7ca</guid>
		 <pubDate>Tue, 20 Aug 2013 05:11:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1999 MB Seeds: 2,819 Peers: 323 Hash: 70b487b9e21e2869af831397851f45a00d3ea7ca</description>
	  </item>
	  <item>
		 <title>The Lone Ranger 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/46fd76d8a49ff787a0e0d58a4c9768770f48a414</link>
		 <guid>http://torrentz.eu/46fd76d8a49ff787a0e0d58a4c9768770f48a414</guid>
		 <pubDate>Thu, 03 Oct 2013 13:20:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 987 MB Seeds: 2,985 Peers: 139 Hash: 46fd76d8a49ff787a0e0d58a4c9768770f48a414</description>
	  </item>
	  <item>
		 <title>The Hobbit The Desolation of Smaug 2013 FRENCH REPACK BDRip XviD QCP avi</title>
		 <link>http://torrentz.eu/ce68d29382576f09c3121acc6e1d9e4e39b36230</link>
		 <guid>http://torrentz.eu/ce68d29382576f09c3121acc6e1d9e4e39b36230</guid>
		 <pubDate>Fri, 21 Mar 2014 11:06:28 +0000</pubDate>
		 <category> movies video</category>
		 <description>Size: 1397 MB Seeds: 2,916 Peers: 180 Hash: ce68d29382576f09c3121acc6e1d9e4e39b36230</description>
	  </item>
	  <item>
		 <title>Paranormal Activity The Marked Ones 2014 UNRATED HDRip XviD AQOS</title>
		 <link>http://torrentz.eu/984c66b56479a1e496266f15c80809bc7e6c599c</link>
		 <guid>http://torrentz.eu/984c66b56479a1e496266f15c80809bc7e6c599c</guid>
		 <pubDate>Tue, 25 Mar 2014 09:48:13 +0000</pubDate>
		 <category>xvid movies divx video</category>
		 <description>Size: 910 MB Seeds: 2,521 Peers: 517 Hash: 984c66b56479a1e496266f15c80809bc7e6c599c</description>
	  </item>
	  <item>
		 <title>Captain Phillips 2013 DVDRip XviD MAXSPEED</title>
		 <link>http://torrentz.eu/4a68200cc82d8d5e9aba9882e2f0a436f8722ded</link>
		 <guid>http://torrentz.eu/4a68200cc82d8d5e9aba9882e2f0a436f8722ded</guid>
		 <pubDate>Tue, 07 Jan 2014 11:08:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 1393 MB Seeds: 2,560 Peers: 441 Hash: 4a68200cc82d8d5e9aba9882e2f0a436f8722ded</description>
	  </item>
	  <item>
		 <title>Captain Phillips 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/e91893277731150ac4f116dc6b178c973238d47c</link>
		 <guid>http://torrentz.eu/e91893277731150ac4f116dc6b178c973238d47c</guid>
		 <pubDate>Sat, 11 Jan 2014 06:08:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 924 MB Seeds: 2,791 Peers: 205 Hash: e91893277731150ac4f116dc6b178c973238d47c</description>
	  </item>
	  <item>
		 <title>Thor Le Monde Des Tenebres 2013 French Movies DVDRip GLOUBi</title>
		 <link>http://torrentz.eu/d45ef19dd93bc3f701b40a91b32435b8cf23ab01</link>
		 <guid>http://torrentz.eu/d45ef19dd93bc3f701b40a91b32435b8cf23ab01</guid>
		 <pubDate>Thu, 06 Feb 2014 07:07:07 +0000</pubDate>
		 <category>movies divx xvid</category>
		 <description>Size: 702 MB Seeds: 2,889 Peers: 98 Hash: d45ef19dd93bc3f701b40a91b32435b8cf23ab01</description>
	  </item>
	  <item>
		 <title>Bad Asses 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/6f9105790749eecb3244c659e0db6fd2701cb48c</link>
		 <guid>http://torrentz.eu/6f9105790749eecb3244c659e0db6fd2701cb48c</guid>
		 <pubDate>Thu, 27 Mar 2014 09:23:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1272 MB Seeds: 2,649 Peers: 327 Hash: 6f9105790749eecb3244c659e0db6fd2701cb48c</description>
	  </item>
	  <item>
		 <title>Monsters University 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/ec588087d7604eae3b840560e6659d57a89b230e</link>
		 <guid>http://torrentz.eu/ec588087d7604eae3b840560e6659d57a89b230e</guid>
		 <pubDate>Fri, 11 Oct 2013 00:40:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 810 MB Seeds: 2,797 Peers: 155 Hash: ec588087d7604eae3b840560e6659d57a89b230e</description>
	  </item>
	  <item>
		 <title>Seal Team Eight: Behind Enemy Lines 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/5ab2ab6a95d98513f5dc82bcdf533d7ebed4b3ea</link>
		 <guid>http://torrentz.eu/5ab2ab6a95d98513f5dc82bcdf533d7ebed4b3ea</guid>
		 <pubDate>Thu, 20 Mar 2014 11:45:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 756 MB Seeds: 2,310 Peers: 638 Hash: 5ab2ab6a95d98513f5dc82bcdf533d7ebed4b3ea</description>
	  </item>
	  <item>
		 <title>Nebraska 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/d1f87a13f66909dcb58ec23ee2db8bf1e9bf4186</link>
		 <guid>http://torrentz.eu/d1f87a13f66909dcb58ec23ee2db8bf1e9bf4186</guid>
		 <pubDate>Wed, 12 Feb 2014 05:43:36 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 865 MB Seeds: 2,751 Peers: 150 Hash: d1f87a13f66909dcb58ec23ee2db8bf1e9bf4186</description>
	  </item>
	  <item>
		 <title>Fast and Furious 6 2013 1080p EXTENDED BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/99d461c4746d590e8d91b43da17c53c7b435db2e</link>
		 <guid>http://torrentz.eu/99d461c4746d590e8d91b43da17c53c7b435db2e</guid>
		 <pubDate>Mon, 02 Sep 2013 12:17:02 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1992 MB Seeds: 2,637 Peers: 260 Hash: 99d461c4746d590e8d91b43da17c53c7b435db2e</description>
	  </item>
	  <item>
		 <title>Dishkiyaoon 2014 Hindi 720p HDRip x264 AAC Hon3y</title>
		 <link>http://torrentz.eu/61d722ab93905b6d310fc6aef33edfd0597d5a2a</link>
		 <guid>http://torrentz.eu/61d722ab93905b6d310fc6aef33edfd0597d5a2a</guid>
		 <pubDate>Fri, 28 Mar 2014 15:00:26 +0000</pubDate>
		 <category>movies hd</category>
		 <description>Size: 846 MB Seeds: 1,837 Peers: 1,046 Hash: 61d722ab93905b6d310fc6aef33edfd0597d5a2a</description>
	  </item>
	  <item>
		 <title>White House Down 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/727665e0fe70263cd0b715758c2e8db9a78554ec</link>
		 <guid>http://torrentz.eu/727665e0fe70263cd0b715758c2e8db9a78554ec</guid>
		 <pubDate>Thu, 10 Oct 2013 18:52:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 925 MB Seeds: 2,724 Peers: 151 Hash: 727665e0fe70263cd0b715758c2e8db9a78554ec</description>
	  </item>
	  <item>
		 <title>The Internship 2013 UNRATED 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/3bea15c9fcda1db425b2bf010351f0d3f1b57408</link>
		 <guid>http://torrentz.eu/3bea15c9fcda1db425b2bf010351f0d3f1b57408</guid>
		 <pubDate>Thu, 10 Oct 2013 12:44:00 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 869 MB Seeds: 2,703 Peers: 122 Hash: 3bea15c9fcda1db425b2bf010351f0d3f1b57408</description>
	  </item>
	  <item>
		 <title>The Pirate Fairy 2014 1080p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/3cfabee6c46f0068bf9d63dd811935965bb8beed</link>
		 <guid>http://torrentz.eu/3cfabee6c46f0068bf9d63dd811935965bb8beed</guid>
		 <pubDate>Thu, 20 Mar 2014 20:15:15 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 1255 MB Seeds: 2,462 Peers: 359 Hash: 3cfabee6c46f0068bf9d63dd811935965bb8beed</description>
	  </item>
	  <item>
		 <title>Grudge Match 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/ae6fc6240abc32224f64833eecf11a11b7f6cae6</link>
		 <guid>http://torrentz.eu/ae6fc6240abc32224f64833eecf11a11b7f6cae6</guid>
		 <pubDate>Thu, 27 Mar 2014 03:26:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 813 MB Seeds: 2,387 Peers: 368 Hash: ae6fc6240abc32224f64833eecf11a11b7f6cae6</description>
	  </item>
	  <item>
		 <title>The Family 2013 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/966658c2d29bd07bfa8e1cf7e3fe97a20d9af4da</link>
		 <guid>http://torrentz.eu/966658c2d29bd07bfa8e1cf7e3fe97a20d9af4da</guid>
		 <pubDate>Fri, 06 Dec 2013 05:44:01 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 814 MB Seeds: 2,613 Peers: 119 Hash: 966658c2d29bd07bfa8e1cf7e3fe97a20d9af4da</description>
	  </item>
	  <item>
		 <title>Philomena 2013 DVDSCR XViD NINJA</title>
		 <link>http://torrentz.eu/42221f6aa6776c723e1d3f3b2154d5522146a869</link>
		 <guid>http://torrentz.eu/42221f6aa6776c723e1d3f3b2154d5522146a869</guid>
		 <pubDate>Thu, 06 Feb 2014 08:39:01 +0000</pubDate>
		 <category>movies divx xvid video</category>
		 <description>Size: 782 MB Seeds: 2,638 Peers: 78 Hash: 42221f6aa6776c723e1d3f3b2154d5522146a869</description>
	  </item>
	  <item>
		 <title>Reasonable Doubt 2014 720p BrRip x264 YIFY</title>
		 <link>http://torrentz.eu/48c6f7cec1553bbe0301cebd08f675d2efbd4bb6</link>
		 <guid>http://torrentz.eu/48c6f7cec1553bbe0301cebd08f675d2efbd4bb6</guid>
		 <pubDate>Wed, 05 Mar 2014 12:00:57 +0000</pubDate>
		 <category>brrip movies hd video</category>
		 <description>Size: 749 MB Seeds: 2,514 Peers: 185 Hash: 48c6f7cec1553bbe0301cebd08f675d2efbd4bb6</description>
	  </item>
	 </channel>
</rss>";
        }


        #endregion
    }

}
