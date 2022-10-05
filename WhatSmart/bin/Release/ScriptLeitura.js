var processando = "false";
var respondendo = "false";
var Contatos = [];
var objContato = {Nome:"", Telefone:"", Mensagens:[]};

function simulateMouseEvents(element, eventName) {
    var mouseEvent= document.createEvent ('MouseEvents');
    mouseEvent.initEvent (eventName, true, true);
    element.dispatchEvent (mouseEvent);
}

document.getElementsByClassName("selectable-text")[0]
function lerUltimasMensagens(item){
	let lista = document.getElementsByClassName("selectable-text");
	
	if(lista.length>0){
		console.log(lista.length + " mensagens internas" );
		for(let i=lista.length-2; i>=0; i--){
			var item = lista[i];
			if(item.innerText!=null){
				
				var superPai = item.offsetParent.parentElement.parentElement.parentElement.parentElement.parentElement;
				//console.log('CLASS:' + superPai.className)
				simulateMouseEvents(superPai, 'mouseenter');
				simulateMouseEvents(superPai, 'mousedown');
				simulateMouseEvents(superPai, 'focus');
				if(superPai.className.indexOf("message-in")!=-1){
					console.log("[MSG in] " + i + " - " + item.innerText);
					//objContato.Mensagens[i]= item.innerText;
					if(item.innerText!=null)
						objContato.Mensagens.push(item.innerText);
				}
				else if(superPai.className.indexOf("message-out")!=-1 && (objContato.Telefone==null || objContato.Telefone=="")){
					console.log("[MSG out] " + i + " - " + item.innerText);
					objContato.Telefone = item.offsetParent.parentElement.parentElement.parentElement.parentElement.parentElement.getAttribute("data-id");
					//console.log(item.offsetParent.parentElement.parentElement.parentElement.parentElement.parentElement.getAttribute("data-id"));
					
					objContato.Telefone = objContato.Telefone.substring(7,objContato.Telefone.indexOf('@'));
					//console.log('TELEFONE: ' + objContato.Telefone);
					alert(objContato.Telefone);
				}
				
			}
			
				
		}
		
		//Contatos.push(objContato);
	}

	/*var elclick = document.querySelectorAll('div[title*="Digite uma mensagem"]')[0];
	// local para aguarda respondendo e respostas
	respondendo = "true";
	simulateMouseEvents(elclick, 'mousedown');
	simulateMouseEvents(elclick, 'focus');
	simulateMouseEvents(item, 'mousedown');*/
	setTimeout(function(){GetNovasMensagens();},2000);
	
	
}

function iniciaProcesso(item){
	simulateMouseEvents(item, 'mousedown');
	setTimeout(function(){lerUltimasMensagens(item);}, 3000);
}

//var ContatoAtual = "";

function Getlista(){
	return lista.lenght;
}
function GetNovasMensagens(){
	processando = "true";
	respondendo = "false";
	let lista = document.querySelectorAll('span[aria-label*="mensage"]');
	console.log("Foram encontrados " + lista.length + " novas mensagens");
	
	
	if(lista.length>0){
		var i = 0;
		var achou = false;
		do
		{
			var item = lista[i];
			try{
				
				console.log("CT["+i+"] - " + item.offsetParent.children[1].children[0].children[0].innerText);
				if(objContato.Nome != item.offsetParent.children[1].children[0].children[0].innerText){
				//if(ContatoAtual != item.offsetParent.children[1].children[0].children[0].innerText)
					objContato = {Nome:"", Telefone:"", Mensagens:[]};
					achou = true;
					
					//ContatoAtual=item.offsetParent.children[1].children[0].children[0].innerText; 
					objContato.Nome=item.offsetParent.children[1].children[0].children[0].innerText; 
					var tel = objContato.Nome.replace(" ", "").replace("+","").replace("-" ,"");
					
					if(isNaN(tel)==false){
						objContato.Telefone = tel;
					}
					else{
						// Parte aonde pegamos o contato via foto
						//var item = document.querySelectorAll('span[aria-label*="mensage"]')[0]
						//item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement;
						var link = item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].children[0].children[1].src
						link = link.substring(link.indexOf('u=')+2);
						link = link.substring(0, link.indexOf('%'));
						objContato.Telefone = link;
						
						// final do código aonde pegamos o contato
					}
				Contatos.push(objContato);
				}
				else i++;
			}
			catch(e){
				if(item != null && item.parentElement != null && item.parentElement.parentElement != null && item.parentElement.parentElement.parentElement != null && 
				item.parentElement.parentElement.parentElement.parentElement != null && item.parentElement.parentElement.parentElement.parentElement.parentElement && 
				item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText != null){
				var ctx = item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText;
				ctx = ctx.substring(0,17);
				console.log("CTX["+i+"] - " + ctx);
				//if(ContatoAtual != item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText){
					if(objContato.Nome != item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText){
				
					objContato = {Nome:"", Telefone:"", Mensagens:[]};
					achou = true;
					
					//ContatoAtual=item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText;
					objContato.Nome=item.parentElement.parentElement.parentElement.parentElement.parentElement.innerText;
					var tel = objContato.Nome.replace(" ", "").replace("+","").replace("-" ,"");
					if(isNaN(tel)==false){
						objContato.Telefone = tel;
					    
					}
					else{
						// Parte aonde pegamos o contato via foto
						//var item = document.querySelectorAll('span[aria-label*="mensage"]')[0]
						//item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement
						
						if(item != null && item.parentElement != null && item.parentElement.parentElement != null && item.parentElement.parentElement.parentElement != null && 
				item.parentElement.parentElement.parentElement.parentElement != null && item.parentElement.parentElement.parentElement.parentElement.parentElement && 
				item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement != null && item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement != null
				&& item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0] != null && item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0]
				!= null && item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0] != null &&
				item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].children[0] != null &&
				item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].children[0].children[1] != null &&
				item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].children[0].children[1].src != null){
				
						var link = item.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].children[0].children[1].src
						link = link.substring(link.indexOf('u=')+2)
						link = link.substring(0, link.indexOf('%'))
						objContato.Telefone = link;
				}
						
						// final do código aonde pegamos o contato
					}
					Contatos.push(objContato);
				}
				else i++;
				}}
		}
		while(achou==false && i<=lista.length);
		
		if(achou){
			setTimeout(function(){iniciaProcesso(lista[i]);}, 100);
			
		}
		else {
			console.log("\r\n\r\nNAO ACHOU MENSAGENS NOVAS");
			objContato =  {Nome:"", Telefone:"", Mensagens:[]};
			//ContatoAtual = "";
			console.log(Contatos);
			processando = "false";
			respondendo = "false";
		}
	}
	else {
		//ContatoAtual = "";
		objContato =  {Nome:"", Telefone:"", Mensagens:[]};
		console.log("\r\n\r\nFINALIZOU TUDO");
		console.log(Contatos);
		processando = "false";
		respondendo = "false";
	}
	return true;
	
}

function IsProcessando()
{
	return processando;
}
function IsRespondendo(){
	
	return respondendo;
}

function PushContatos(){
	
	console.log("PEGANDO CONTATOS NOVOS");
	return Contatos;
}

var achouBotaoSend = false;
var clicouBotaoSend = false;
//Comando Envio
function openChat(phone, texto) {
	achouBotaoSend = false;
	clicouBotaoSend = false;
	const link = document.createElement('a');
	link.setAttribute('href', `whatsapp://send?phone=${phone}&text=${texto}`);
	document.body.append(link);
	link.click();
	document.body.removeChild(link);
	setTimeout(function(){ClicaEnvio();}, 100);
	
 }
				 
function ClicaEnvio(){
	var bot = document.querySelectorAll('[data-icon=\"send\"]')[0];
	if(bot==null || bot==undefined)
	{
		if(achouBotaoSend==false)
		{
			setTimeout(function(){ClicaEnvio();}, 100);
			return;
		}
		else{
			clicouBotaoSend = true;
		}
	}
	else if(achouBotaoSend==false){
		achouBotaoSend = true;
		if(bot.parentElement!=null){
			bot.parentElement.click();
			
			setTimeout(function(){ClicaEnvio();}, 100);
		}
		else {
			console.log(bot);
			alert("erro desconhecido1");
		}
	}
	else if(achouBotaoSend==true){
		
		if(bot.parentElement!=null){
			bot.parentElement.click();			
			setTimeout(function(){ClicaEnvio();}, 100);
		}
		else {
			console.log(bot);
			alert("erro desconhecido2");
		}
	}
}

function VerificaClickBotaoSend(){
	return clicouBotaoSend;
}

//Comando VerificaConexao
function VerificaConexao(){
                if(document.getElementsByTagName('h1')[0].outerText.indexOf('Mantenha seu celular conectado')!=-1){
					window.chrome.webview.postMessage('SistemaConectado');
					}
			    else{
					window.chrome.webview.postMessage('SistemacccccConectado');}
					}
function replacetel(){
	tel = item.telefone.replace(" ", "").replace("+","").replace("-" ,"");
	return tel;
}
