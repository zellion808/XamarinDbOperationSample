# XamarinAzureDBOperationSample
【Xamarin】AzureのSQL Databaseへの読み書きを行うAPIの開発手順、アプリ側の実装手順です

# 手順（備忘録）
## API開発
1. Azureでリソースグループ、SQLサーバ、SQL Databaseを作成する  
2. VisualStudioでプロジェクトを作成する  
3. ASP.Net Web Applicationテンプレートを選択し新規作成を行う  
4. テンプレートの選択が表示されるので、Azure API Appを選択する  
5. 作成されたプロジェクトに対し、NuGetパッケージマネージャーより必要なものを追加する  
・EntityFramework  
・Swashbuckle  
・Newtonsoft Json  
6. 作成されたプロジェクトのModelsフォルダーにDAL(Data Access Layer)クラスを追加し、記述する  
DALクラスはDbContextクラスを継承します  
例）  
```
SampleDbContext.cs  

	using System.Data.Entity;			
	public class SampleDbContext : DbContext			
	{			
		public DbSet<Project> Projects { get; set; } ←テーブルとする対象のモデルを定義する。		
		public DbSet<Member> Members { get; set; }		
		～中略		
				
		protected override void OnModelCreating(DbModelBuilder modelBuilder)		
		{		
			base.OnModelCreating(modelBuilder);	
		}		
	}		
```
7. 	プロジェクトのModelsフォルダーにモデルクラスを追加し、記述を行う  
モデルクラス名は対象の単数形となるようにする  
作成したモデルクラスのusingディレクティブに以下を追加する  
using System.ComponentModel.DataAnnotations;  

8. テーブル列の定義  
テーブルの列をモデルクラスのパブリックメンバーとして記述します  
テーブルの列であるパブリックメンバーはgetおよびsetアクセサを持つようにします  
PK、FK、Not Null属性、桁数属性などはアノテーションを記述し、定義します  
例）  
[key] PK  
[Key, Column(Order = 1)] PKが複数ある場合  
(using System.ComponentModel.DataAnnotations.Schema;が必要)  
[Required] Not Null属性  
[MaxLength(256)] 桁数属性  
[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 自動採番

9. リレーションシップの定義  
1:n、n:n、1:1or0の関係のリレーションシップの定義を行うことが可能  
本サンプルでは未使用

10. アプリケーション実行時の処理をGlobal.asax.csに記述する  
アプリケーション実行時、DBが存在しない場合自動で作成するように記述を行います

```
protected void Application_Start()	
{	
	GlobalConfiguration.Configure(WebApiConfig.Register);
	Database.SetInitializer(new CreateDatabaseIfNotExists<SampleDbContext>());
}
```

11. Web.configにDBへの接続文字列を定義する  
configration直下にconnectionStringsを定義する  
例）
```
<configration>						
	<connectionStrings>					
		<add name="SampleDbContext" providerName="System.Data.SqlClient" 				
			connectionString="Server=tcp:sample.database.windows.net,1433;Initial Catalog=SampleDB;Persist Security Info=False;			
			User ID=sample;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" />			
	</connectionStrings>					
```

12. Web.configにHTTPSリダイレクトを定義する  
APIに対しHTTPS通信を行いアクセスする場合、Web.configにリダイレクト設定の定義を記述する  
例）
```
<system.webServer>						
	  <!-- HTTPSリダイレクト -->					
	  <rewrite>					
		  <rules>				
			  <rule name="Force HTTPS" enabled="true">			
				  <match url="(.*)" ignoreCase="false" />		
				  <conditions>		
					  <add input="{HTTPS}" pattern="off" />	
				  </conditions>		
				  <action type="Redirect" url="https://{HTTP_HOST}/{R:1}" appendQueryString="true" redirectType="Permanent" />		
			  </rule>			
		  </rules>				
	  </rewrite>					
```

13. コントローラークラスを作成する  
クライアントから呼び出されて実際に処理を行うコントローラークラスを生成する  
13.1 ソリューションエクスプローラーでControllersフォルダを右クリックし、追加=>コントローラーの順に選択する  
13.2 Entity Framework を使用したアクションがある Web API 2 コントローラーを選択し、追加をクリックする  
13.3 読み書き対象とするモデルクラスおよびDALを指定し追加をクリック  

14. 後の工程で行うREST API クライアント生成で必要となるSwaggerを取得できるようにするため、Swaggerを公開するように修正を行う  
以下のコメント化されている個所をアンコメントする
```
// ***** Uncomment the following to enable the swagger UI *****																								
/*					←削除する			
})																								
.EnableSwaggerUi(c =>																								
{																								
*/					←削除する			
```

15. Web APIをAzure上にデプロイする  
https://docs.microsoft.com/ja-jp/azure/app-service-api/app-service-api-dotnet-get-started　を参考にWeb APIをAzure上にデプロイする  

16. Swaggerで操作が可能になっていれば成功

## アプリ開発
1. http://furuya02.hatenablog.com/entry/2014/10/05/053525　を参考にHTTPClientでリクエストを送る


# その他備忘録
## APIのリモートデバッグの方法
https://blogs.msdn.microsoft.com/tsmatsuz/2013/01/31/visual-studio-azure-remote-debug/  
VSのサーバーエクスプローラー画面からデプロイしたAPIを右クリックし、デバッガーのアタッチ

## データベースマイグレーション
調査中...

# 参考URL
https://docs.microsoft.com/ja-jp/azure/app-service-api/app-service-api-dotnet-get-started  
