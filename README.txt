-------------------------------------------------------------------------
XtremeVote (c) by Shady Khailfa

XtremeVote is licensed under a
Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License.

You should have received a copy of the license along with this
work. If not, see <http://creativecommons.org/licenses/by-nc-nd/4.0/>.
--------------------------------------------------------------------------

XtremeVote - V0.1.0
-------------------------------
xtremetop100.com postback handler.

* Configrations:

1. Open config.toml file
2. Edit your informations
3. `site_id` can be found from xtreamtop100 url
    for example: http://www.xtremetop100.com/in.php?site=1132363231
                                                         ||||||||||               
    -----------------------------------------------------++++++++++
4. `database_url` is the path where we will save data, leave it as it if you want.
5. make sure to edit `vote_config` too.
6. Run xtremevote.exe
7. Open your web browser and check http://IP:PORT
8. Go to your xtreamtop100 control panel and set the postback url to: http://IP:PORT/postback

* Game Server (C#):

Note: REQUIRES .NET Framework v4.5 or Higher.

1. Open `Helper` folder, and copy files to your bin/Debug or bin/Relase Folder.
2. Copy xtremevote.exe with sqlite3.dll and config.toml to your bin/Debug or bin/Relase Folder.
3. Start xtremevote.exe again.
4. Open your Project and add XtremeVoteHelper.dll to your project referances.
4. Open your Program.cs
5. add these lines in top of your program:

  public static VoteDB = new XtremeVoteHelper.Controller(servicePort); // Change servicePort to your PORT from config.toml

6. Then in your NPC you can check for points like so:

   int points = Program.VoteDB.GetPlayerPoints(username).Result; // Change username to the player username.

   // later to set the player points
   Program.VoteDB.SetPlayerPoints(username, points).Wait();

7. Done, Do something with points.

* Web Server Configrations [OPTINAL]:

1. Open your .htaccess file
2. add these lines to it

RewriteEngine on
RewriteRule ^/?vote http://YOUR_SERVER_IP_OR_DOMAIN:PORT [R=301,L]

3. Now Check http://YOUR_SERVER_IP_OR_DOMAIN/vote

