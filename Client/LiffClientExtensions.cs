using LineDC.Liff;
using Microsoft.JSInterop;

namespace BlazorApp.Client
{
    public static class LiffClientExtensions
    {
        /// <summary>
        /// 各ページの初期化イベント
        /// </summary>
        /// <param name="liff"></param>
        /// <param name="jSRuntime"></param>
        /// <returns></returns>
        public static async Task<bool> InitializeAsync(this ILiffClient liff, IJSRuntime jSRuntime)
        {
            //初期化済みの場合は何もしない
            if (liff.Initialized)
            {
                return true;
            }
            //LIFFの初期化
            await liff.Init(jSRuntime);
            //ログイン済みでない場合
            if (!await liff.IsLoggedIn())
            {
                //LINEのログイン画面にリダイレクト
                await liff.Login();
                //初期化完了していないのでfalseを返す
                return false;
            }
            //ログイン済みの場合、初期化済みフラグを立てる
            liff.Initialized = true;
            //初期化済みとしてtrueを返す
            return true;
        }
    }
}
