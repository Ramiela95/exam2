# Galaxy

Progetto per la dominazione del mondo!

## Comandi Git per la clonazione del sorgente e creazione versione di lavoro

Data una cartella di lavoro sul proprio pc personale 
posizionata in `C:\\academy\\module-2\\`:
- Creare una cartella **original_src**
- Creare una cartella **working_src**
- Entrare nella cartella *original_src*
- Aprire Git Bash nella cartella
- Clonare il sorgente originale 
  - `git clone https://github.com/maurobussini/helloacademy.git`
- Entrare nella cartella *working_src*
- Aprire Git Bash nella cartella
- Clonare il sorgente originale 
  - `git clone https://github.com/maurobussini/helloacademy.git`
- Entrare nella folder **helloacademy**
- Rimuovere la remote origin dal repository
  - `git remote remove origin`
- Aggiungere la nuova origine al repository di lavoro
  - `git remote add origin https://github.com/maurobussini/helloacademy_working.git`
- Lavorare sul repository di lavoro
- Aggiungere i nuovi file e le modifiche
  - `git add .`
- Eseguire il commit delle modifiche in locale
  - `git commit -m "Message with commit changes"`
- Eseguire il push delle modifiche sul repository remoto 
  - `git push -u origin master`