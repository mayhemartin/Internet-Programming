<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IP_FinalProject._Default" MasterPageFile="~/MasterPages/Booking.Master" %>

<asp:Content ID="Attractions" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <div style="width:80%; text-align:center; margin:auto; padding-left:130px;">
		<div id="slideShowImages" class="Content-slideshow">
		    <div class="featureItem"><a href="http://www.texasstateaquarium.org" target="_blank"><img src="Images/Attractions/aquarium.jpg" title="Texas State Aquarium" alt="FISH!!" /></a></div>
            <div class="featureItem"><a href="http://www.milb.com/index.jsp?sid=t482" target="_blank"><img src="Images/Attractions/cchooks.jpg" title="Corpus Christi Hooks" alt="BASEBALL!!" /></a></div>
		    <div class="featureItem"><a href="http://www.usslexington.com" target="_blank"><img src="Images/Attractions/ussLexington.jpg" title="The U.S.S. Lexington" alt="THE LEXINGTON!!" /></a></div>
            <div class="featureItem"><a href="http://www.goicerays.com" target="_blank"><img src="Images/Attractions/icerays.jpg" title="Corpus Christi Ice Rays" alt="HOCKEY !!" /></a></div>
            <div class="featureItem"><a href="http://www.tpwd.state.tx.us/state-parks/mustang-island" target="_blank"><img src="Images/Attractions/misp.jpg" title="Mustang Island State Park" alt="BEACH !!" /></a></div>
            <div class="featureItem"><a href="http://www.nps.gov/pais/index.htm" target="_blank"><img src="Images/Attractions/pins.jpg" title="Padre Island National Seashore" alt="MORE BEACH !!" /></a></div>
		</div>
    </div>
    <script type="text/javascript" src="Scripts/slideShow.js"></script>

    <p style="width:70%; margin:auto;">Enjoy the <b>attractions</b> in and around the city of Corpus Christi. Click an image for more information, 
    or expand a link below for a brief teaser of information on the attraction your interested in.</p>

    <div id="attr_Aquarium" class="desc_center">
        <a href="#hide1" class="hide" id="hide1">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Texas State Aquarium
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show1" class="show" id="show1">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Texas State Aquarium
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        The Texas State Aquarium is a nonprofit aquarium located in Corpus Christi, Texas.  It is dedicated to
                        promoting environmental conservation and rehabilitation of the wildlife of the Gulf of Mexico. It has
                        been accredited by the Association of Zoos and Aquariums (AZA) since 1995.<br />
                    </td>
                </tr>
                <tr class="desc_center" style="text-align:left;">
                    <td style="padding-left:10%;">
                        <u>Current Exhibits</u>
                        <ul>                
                            <li>Amazon</li>
                            <li>Dolphin Bay</li>
                            <li>Eagle Pass</li>
                            <li>Floating Phantoms</li>
                            <li>Flower Gardens</li>
                            <li>Hawn Wild Flight Theater</li>
                            <li>Islands of Steel</li>
                            <li>Living Shores</li>
                            <li>Otter Creek</li>
                            <li>Stingray Flats</li>
                            <li>Swamp Tales</li>
                            <li>Tortuga Cay</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://www.texasstateaquarium.org" target="_blank">Texas State Aquarium - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wikipedia.org/wiki/Texas_State_Aquarium" target="_blank">Wikipedia</a><br />
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />
    <div id="attr_Hooks" class="desc_center">
        <a href="#hide2" class="hide" id="hide2">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Corpus Christi Hooks
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show2" class="show" id="show2">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Corpus Christi Hooks
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        The Corpus Christi Hooks are a minor league baseball team of the Texas League, and
                        are the Double-A affiliate of the Houston Astros. They are located in Corpus Christi, Texas,
                        and are named for the city's association with fishing. The team's ownership group is
                        headed by Baseball Hall of Famer Nolan Ryan; the team's CEO, Reid Ryan, is Nolan's oldest
                        son. The Hooks play their home games at Wahaburger Field, which opened in 2005 and
                        is located on Corpus Christi's waterfront.<br /><br />

                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://www.milb.com/index.jsp?sid=t482" target="_blank">Corpus Christi Hooks - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wikipedia.org/wiki/Corpus_Christi_Hooks" target="_blank">Wikipedia</a><br />
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />
    <div id="attr_Lexington" class="desc_center">
        <a href="#hide3" class="hide" id="hide3">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        The U.S.S. Lexington
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show3" class="show" id="show3">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        The U.S.S. Lexington
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        USS Lexington (CV/CVA/CVS/CVT/AVT-16), nicknamed "<i>The Blue Ghost</i>", is
                        an Essex-class aircraft carrier built during World War II for the United States Navy. 
                        Origionally intended to be named Cabot, word arrived during construciton that the USS 
                        Lexington (CV-2) had been lost in the Battle fo the Coral Sea. She was renamed while 
                        under construction to commemorate the earlier ship. This ship was the fifth US Navy 
                        ship to bear the name in honor of the Revolutionary War Battle of Lexington.<br /><br />

                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://usslexington.com" target="_blank">U.S.S. Lexington - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wkipedia.org/wiki/USS_Lexington_(CV-16)" target="_blank">Wikipedia</a><Br />
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />
    <div id="attr_icerays" class="desc_center">
        <a href="#hide4" class="hide" id="hide4">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        The Corpus Christi IceRays
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show4" class="show" id="hide4">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        The Corpus Christi IceRays
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        The Corpus Christi IceRays are a Junior A ice hockey team playing in the 
                        North American Hockey League (NAHL). The IceRays are based in Corpus Christi, 
                        Texas and play in the North American Hockey League's South Division. 
                        The "IceRays" moniker derives from the many different species of stingrays 
                        who inhabit the nearby Gulf of Mexico. The team's current head coach is John Becanic.<br /><br />

                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://goicerays.pointstreaksites.com/view/goicerays" target="_blank">Corpus Christi IceRays - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wikipedia.org/wiki/Corpus_Christi_IceRays" target="_blank">Wikipedia</a><Br />
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />
    <div id="attr_misp" class="desc_center">
        <a href="#hide5" class="hide" id="hide5">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Mustang Island State Park
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show5" class="show" id="show5">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Mustang Island State Park
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        Mustang Island State Park is a state park located south of the city of Port Aransas, Texas 
                        on the coast of the Gulf of Mexico that covers 3,954 acres and has a 5-mile beachfront. 
                        The land was acquired from private owners in 1972 and opened to the public in 1979.<br /><br />

                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://www.tpwd.state.tx.us/state-parks/mustang-island" target="_blank">Mustang Island State Park - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wikipedia.org/wiki/Mustang_Island_State_Park" target="_blank">Wikipedia</a><Br />
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />
    <div id="attr_pins" class="desc_center">
        <a href="#hide6" class="hide" id="hide6">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Padre Island National Seashore
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_down.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <a href="#show6" class="show" id="show6">
            <table class="description">
                <tr>
                    <td class="desc_left">
                        Padre Island National Seashore
                    </td>
                    <td class="desc_right">
                        <img src="img/arrow_up.jpg" alt="" />
                    </td>
                </tr>
            </table>
        </a>
        <div class="list">
            <table>
                <tr class="desc_center">
                    <td>
                        <b>Padre Island National Seashore (PAIS)</b> is a National Seashore located on Padre Island off the coast
                        of South Texas. In contrast to South Padre Island, known for its beaches and vacationing college students, 
                        PAIS is located on North Padre Island and consists of a long beach where nature is preserved. <br /><br />

                        Most of the park is primitive, but camping is available, and most of the beach is only accessible to 
                        four-wheel-drive vehicles. All but four miles is open to vehicle traffic. PAIS is the fourth designated 
                        national seashore in the United States.<br /><br />

                        North Padre Island is the longest undeveloped barrier island in the world. The National Seashore is 70 miles 
                        long with 65.5 miles of Gulf beach. PAIS hosts a variety of pristine beach, dune, and tidal flat environments, 
                        including the Laguna Madre on its west coast, a famous spot for windsurfing. It is located in parts of Kleberg, 
                        Kenedy, and Willacy counties, with Kenedy County having the majority of its land area.<br /><br />

                        <u><b>For More Information</b></u><br />
                        &nbsp;&nbsp;<a href="http://www.nps.gov/pais/index.htm" target="_blank">Padre Island National Seashore - Main Page</a><br />
                        &nbsp;&nbsp;<a href="http://en.wikipedia.org/wiki/Padre_Island_National_Seashore" target="_blank">Wikipedia</a><Br /> 
                    </td>
                </tr>
            </table>
        </div>            
    </div><br />   
</asp:Content>
