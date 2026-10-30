using System;

namespace MIREAConfigMPW2
{
    internal static class Global
    {
        internal static class Repository
        {
            /// <summary>
            /// URL на репозиторий либо путь к файлу тестового репозитория
            /// </summary>
            internal static string Source { get; set; } = "";

            /// <summary>
            /// Режим работы
            /// </summary>
            internal static bool TestMode { get; set; }
        }

        internal static class Package
        {
            /// <summary>
            /// Название пакета
            /// </summary>
            internal static string Name { get; set; } = "";

            /// <summary>
            /// Версия пакета
            /// </summary>
            internal static string Version { get; set; } = "";
        }

        /// <summary>
        /// Название файла с изображением графа
        /// </summary>
        internal static string GraphPath { get; set; } = "";
    }
}
